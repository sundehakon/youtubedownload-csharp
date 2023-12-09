using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using YoutubeExplode;

namespace YoutubeDownloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var youtube = new YoutubeClient();
            Console.Write("Enter the YouTube video ID, this can be found in the link after the 'v =': ");
            string videoid = Console.ReadLine();
            if (videoid != null)
            {
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoid);
                if (streamManifest != null)
                {
                    var streamInfo = streamManifest.GetAudioOnlyStreams().OrderByDescending(s => s.Bitrate).FirstOrDefault();
                    if (streamInfo != null)
                    {
                        Console.Write("Enter video title: ");
                        string videoTitle = Console.ReadLine();
                        if (videoTitle != null)
                        {
                            var fileExtension = streamInfo.Container.Name;
                            var output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{videoTitle}.{fileExtension}");
                            await youtube.Videos.Streams.DownloadAsync(streamInfo, output);
                        }
                    }
                }
            }
        }
    }
}




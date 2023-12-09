using System;
using System.IO;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace YoutubeDownloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var youtube = new YoutubeClient();
            Console.Write("Enter the YouTube video ID, this can be found in the link after the 'v =': ");
            string videoid = Console.ReadLine();
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoid);
            var streamInfo = streamManifest.GetAudioOnly().WithHighestBitrate();
            Console.Write("Enter video title: ");
            string videoTitle = Console.ReadLine();
            var fileExtension = streamInfo.Container.GetFileExtension();
            var output = Path.Combine(Path.GetTempPath(), $"{videoTitle}.{fileExtension}");
            await youtube.Videos.Streams.DownloadAsync(streamInfo, output);
        }
    }
}

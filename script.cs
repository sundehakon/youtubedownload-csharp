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
            Console.Write("Enter the YouTube video ID, this can be found in the link after the "v ="");
            string video-id = Console.ReadLine();
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video-id);
            var streamInfo = streamManifest
        }
    }
}

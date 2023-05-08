namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context,120));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();
            var producer = context.Producers.Find(producerId);
            var albums = producer?.Albums.OrderByDescending(a=>a.Price).ToList();
            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.Producer.Name}");
                sb.AppendLine("-Songs:");
                var songs = album.Songs.OrderByDescending(s => s.Name).ThenBy(s => s.Writer.Name).ToList();
                int songCounter = 1;
                foreach (var song in songs)
                {
                    sb.AppendLine($"---#{songCounter}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer.Name}");
                    songCounter++;
                }
                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }
            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();
            var songs = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,
                    Performers = s.SongPerformers
                    //.Select(sp=>$"{sp.Performer.FirstName} {sp.Performer.LastName}")
                    .OrderBy(sp=>sp.Performer.FirstName)
                    .ThenBy(sp=>sp.Performer.LastName)
                    .ToList(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s=>s.Name)
                .ThenBy(s=>s.WriterName)
                .ToArray();
            int songCounter = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{songCounter}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                foreach (var p in song.Performers)
                {
                    sb.AppendLine($"---Performer: {p.Performer.FirstName} {p.Performer.LastName}");
                }
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
                songCounter++;
            }
            return sb.ToString().Trim();
        }

        public static int GetSeconds(Song song)
        {
            return song.Duration.Minutes * 60 + song.Duration.Seconds;
        }
    }
}

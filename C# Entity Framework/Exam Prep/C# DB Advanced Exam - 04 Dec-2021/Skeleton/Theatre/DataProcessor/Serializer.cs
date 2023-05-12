namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ExportDto;
    using Theatre.Utilities;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Include(t => t.Tickets)
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(tt => tt.RowNumber >= 1 && tt.RowNumber <= 5).Sum(tt => tt.Price),
                    Tickets = t.Tickets.Where(tt => tt.RowNumber >= 1 && tt.RowNumber <= 5).Select(tt => new
                    {
                        Price = tt.Price,
                        RowNumber = tt.RowNumber
                    })
                    .OrderByDescending(tt => tt.Price)
                    .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name);

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            XMLhelper helper = new XMLhelper();

            var playDtos = context.Plays
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating==0? "premiere": p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c=>c.IsMainCharacter)
                    .Select(c=>new ExportActorDto()
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'"
                    })
                    .OrderByDescending(c=>c.FullName)
                    .ToArray()
                })
                .OrderBy(p=>p.Title)
                .ThenBy(p=>p.Genre)
                .ToArray();

            return helper.Serialize(playDtos, "Plays");
        }
    }
}

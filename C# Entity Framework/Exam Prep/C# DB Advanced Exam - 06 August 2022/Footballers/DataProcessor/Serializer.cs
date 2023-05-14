namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .ToArray()
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers
                                    .ToArray()
                                    .Where(tf => tf.Footballer.ContractStartDate >= date)
                                    .Select(tf => new
                                    {
                                        FootballerName = tf.Footballer.Name,
                                        ContractStartDate = tf.Footballer.ContractStartDate.ToString("d",CultureInfo.InvariantCulture),
                                        ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                                        BestSkillType = tf.Footballer.BestSkillType.ToString(),
                                        PositionType = tf.Footballer.PositionType.ToString()
                                    })
                                    .OrderByDescending(f=>f.ContractEndDate)
                                    .ThenBy(f=>f.FootballerName)
                                    .ToArray()
                })
                .OrderByDescending(t=>t.Footballers.Length)
                .ThenBy(t=>t.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}

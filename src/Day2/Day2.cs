using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day2
    {
        public static int RunPart1(string input)
        {
            var totals = new Dictionary<string, int>()
            {
                ["red"] = 12,
                ["green"] = 13,
                ["blue"] = 14
            };

            return input
             .Split(Environment.NewLine)
             .Select(x => x.Split(":"))
             .Select(x => new
             {
                 GameNumber = int.Parse(x[0].Split(" ")[1]),
                 Samples = x[1]
                    .Split(";")
                    .Select(sample => sample
                        .Split(",")
                        .Select(x => x.Trim().Split(" "))
                        .Select(x => new
                        {
                            Color = x[1],
                            Count = int.Parse(x[0])
                        })
                    )
             })
             .Where(x => x.Samples
                    .All(sample => sample
                        .All(value => totals[value.Color] >= value.Count)))
            .Sum(x => x.GameNumber);
        }

        public static int RunPart2(string input)
        {
            return input
             .Split(Environment.NewLine)
             .Select(x => x.Split(":")[1])
             .Select(x =>
                 x.Split(";")
                .Select(sample => sample
                    .Split(",")
                    .Select(x => x.Trim().Split(" "))
                    .Select(x => new
                    {
                        Color = x[1],
                        Count = int.Parse(x[0])
                    })
                )
             )
             .Select(x => x
                .SelectMany(y => y)
                .GroupBy(y => y.Color)
                .Select(y => new
                {
                    Color = y.Key,
                    MinRequired = y.Max(z => z.Count)
                })
             )
             .Sum(x => x
                .Aggregate(1, (acc, x) => acc *= x.MinRequired));
        }
    }
}

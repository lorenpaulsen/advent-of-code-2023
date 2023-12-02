﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class Day1
    {
        private static readonly IEnumerable<string> words =
            ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        private static readonly Dictionary<string, string> stringNumberPairs =
            new(words.SelectMany((x, i) => BuildVariations(x, i + 1)));

        private static IEnumerable<KeyValuePair<string, string>> BuildVariations(string word, int index)
        {
            yield return new(index.ToString(), index.ToString());
            yield return new(word, index.ToString());
            yield return new(new string(word.Reverse().ToArray()), index.ToString());
        }

        public static async Task<int> Run(string input)
        {
            //var input = await File.ReadAllTextAsync("Day1\\input.txt");

            return input
                .Split(Environment.NewLine)
                .Aggregate(0, (acc, line) =>
                {
                    var firstDigit = stringNumberPairs
                        .ToLookup(pair => line.IndexOf(pair.Key), pair => pair.Value)
                        .Where(pair => pair.Key >= 0)
                        .MinBy(pair => pair.Key)!
                        .Single();

                    var secondDigit = stringNumberPairs
                        .ToLookup(pair => line.LastIndexOf(pair.Key), pair => pair.Value)
                        .MaxBy(pair => pair.Key)!
                        .Single();

                    return acc + int.Parse($"{firstDigit}{secondDigit}");
                });
        }
    }
}

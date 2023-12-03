using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    [TestClass()]
    public class AdventOfCode2023Tests
    {
        [TestMethod()]
        public async Task Day1Part2()
        {
            // Part1: 54632
            // Part2: 54019

            var input = File.ReadAllText("Day1/Input.txt");

            var actual = await Day1.Run(input);
            Assert.AreEqual(54019, actual);
        }

        [TestMethod()]
        public void Day2Part1()
        {
            var input = File.ReadAllText("Day2/Input.txt");

            var totals = new Dictionary<string, int>()
            {
                ["red"] = 12,
                ["green"] = 13,
                ["blue"] = 14
            };

            var actual = Day2.RunPart1(input, totals);
            Assert.AreEqual(2406, actual);
        }

        [TestMethod()]
        public void Day2Part2()
        {
            var input = File.ReadAllText("Day2/Input.txt");

            var actual = Day2.RunPart2(input);
            Assert.AreEqual(78375, actual);
        }
    }
}
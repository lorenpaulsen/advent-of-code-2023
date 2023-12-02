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
    public class Day1Tests
    {
        [TestMethod()]
        public async Task RunTestAsync()
        {
            // Part1: 54632
            // Part2: 54019

            var input = File.ReadAllText("Day1/Input.txt");

            var actual = await Day1.Run(input);
            Assert.AreEqual(54019, actual);
        }
    }
}
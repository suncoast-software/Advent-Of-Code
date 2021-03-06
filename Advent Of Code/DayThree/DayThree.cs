﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Advent_Of_Code.DayThree
{
    public class DayThree
    {
        /// <summary>
        /// Part One of Advent of Code Challenge
        /// </summary>
        /// <returns>int</returns>
        public static int CountTrees(int right, int down)
        {
            string[] lines = File.ReadAllLines(@"DayThree\daythreeinput.txt");
            int count = 0;
            for (int y = 0, x = 0; y < lines.Length; y += down, x += right)
            {
                if (lines[y][x % lines[y].Length].ToString() == "#")
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Part 2 Advent of Code Challenge
        /// </summary>
        /// <returns>long</returns>
        public static long FindPartTwo()
        {
           // long prod = 1;
            long[] arg =
            {
                CountTrees(1, 1),
                CountTrees(3, 1),
                CountTrees(5, 1),
                CountTrees(7, 1),
                CountTrees(1, 2)
            };
            return arg.Aggregate<long, long>(1, (current, value) => current * value);
        }
    }
}

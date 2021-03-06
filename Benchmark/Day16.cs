﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    public class Day16
    {
        readonly string[] input = File.ReadAllLines("day16input.txt");

        [Benchmark]
        public int SolvePart1()
        {
            var result = 0;
            string[] ourTicket;
            List<string[]> validTickets = new List<string[]>();
            List<Rule> rules = new();

            var inputStage = 0;
            foreach (var line in input)
            {
                if (line.Trim() == String.Empty)
                {
                    inputStage++;
                    continue;
                }
                else
                {
                    switch (inputStage)
                    {
                        case 0:
                            string[] parts = line.Split(':');
                            var range = parts[1].Split("or");
                            var minRange = range[0].Trim().Split('-');
                            var maxRange = range[1].Trim().Split('-');

                            Rule rule = new Rule();

                            rule.Name = parts[0];
                            rule.MinValue1 = int.Parse(minRange[0]);
                            rule.MinValue2 = int.Parse(minRange[1]);
                            rule.MaxValue1 = int.Parse(maxRange[0]);
                            rule.MaxValue2 = int.Parse(maxRange[1]);

                            rules.Add(rule);

                            break;
                        case 1:
                            if (line.Contains("your ticket:"))
                                continue;
                            ourTicket = line.Split(',');
                            break;
                        case 2:
                            if (line.Contains("nearby tickets:"))
                                continue;
                            string[] nearByTicketNumNums = line.Split(',');
                            int ruleIndex = 0;
                            for (int i = 0; i < nearByTicketNumNums.Length; i++)
                            {
                                var curNum = int.Parse(nearByTicketNumNums[i]);
                                var valid = false;
                                if ((rules[i].MinValue1 <= curNum && rules[i].MaxValue1 >= curNum) || (rules[i].MinValue2 <= curNum && rules[i].MaxValue2 >= curNum))
                                {
                                    valid = true;
                                    validTickets.Add(nearByTicketNumNums);
                                    continue;
                                }

                                if (!valid)
                                    result += curNum;

                                ruleIndex++;
                            }
                            break;
                        default:
                            continue;
                    }
                }
            }
            //foreach (var rule in rules)
            //{
            //    if (rule.Name.Contains("departure"))
            //    {

            //    }
            //}
            
            return result;
        }

        class Rule
        {
            public string Name { get; set; }
            public int MinValue1 { get; set; }
            public int MaxValue1 { get; set; }
            public int MinValue2 { get; set; }
            public int MaxValue2 { get; set; }
        }

        class Ticket
        {
            public List<int> Nums { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class DayOne
    {
        List<int> numbers = new List<int>();
        private void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Challenges\files\dayonedata.txt");
            foreach (var line in lines)
            {
                numbers.Add(int.Parse(line));
            }

        }

        public DayOne()
        {
            LoadData();
        }

        public long GetChallengeResult()
        {
            var pair = GetValuesThatSumTo(2020);
            return pair.Key * pair.Value;
        }

        public KeyValuePair<int, int> GetValuesThatSumTo(int sum)
        {
            
            
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i+1; j < numbers.Count; j++)
                {
                    
                    if (numbers[i] + numbers[j] == sum)
                    {
                        return new KeyValuePair<int, int>(numbers[i],numbers[j]);
                    }
                }
            }
            throw new Exception("Could not find a pair of numbers that sum to "+sum);
        }
    }
}

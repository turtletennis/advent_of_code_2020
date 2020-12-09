using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class Expenses
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

        public Expenses()
        {
            LoadData();
        }

        public long GetDay1ChallengeResult()
        {
            var pair = GetValuesThatSumTo(2020,2);
            return pair[0] * pair[1];
        }

        public long GetDay1Part2ChallengeResult()
        {
            var triplet = GetValuesThatSumTo(2020, 3);
            return triplet[0] * triplet[1] * triplet[2];
        }

        public List<int> GetValuesThatSumTo(int sum,int numValues)
        {
            
            List<int> result=new List<int>();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i+1; j < numbers.Count; j++)
                {
                    if (numValues == 2)
                    {
                        if (numbers[i] + numbers[j] == sum)
                        {
                            result.Add(numbers[i]);
                            result.Add(numbers[j]);
                            return result;
                        }
                    }
                    else
                    {
                        for (int k = j; k < numbers.Count; k++)
                        {
                            if (numValues == 3)
                            {
                                if (numbers[i] + numbers[j] + numbers[k] == sum)
                                {

                                    result.Add(numbers[i]);
                                    result.Add(numbers[j]);
                                    result.Add(numbers[k]);
                                    return result;
                                }
                            }
                        }
                    }
                }
            }
            throw new Exception("Could not find a pair of numbers that sum to "+sum);
        }
    }
}

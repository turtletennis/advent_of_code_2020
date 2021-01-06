using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class JoltAdapters
    {
        private long[] numbers;

        public JoltAdapters()
        {
            LoadData();
        }

        public void LoadData()
        {
            numbers = System.IO.File.ReadAllLines(@"Challenges\files\daytendata.txt").Select(long.Parse).ToArray();
            Array.Sort(numbers);
        }

        public int GetOneJoltMultipliedByThreeJoltDiffences()
        {
            int oneJoltDiffs = 0;
            int threeJoltDiffs = 1; //device has a 3-jolt adapter in it
            long currentJoltage = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                long diff = numbers[i] - currentJoltage;
                if (diff == 1)
                {
                    oneJoltDiffs++;
                }
                else if (diff == 3)
                {
                    threeJoltDiffs++;
                }
                else if (diff != 2)
                {
                    throw new Exception("Invalid Joltage difference found: "+diff);
                }

                currentJoltage = numbers[i];
            }


            return oneJoltDiffs * threeJoltDiffs;

        }

        public long GetTotalNumberOfValidAdapterCombinations()
        {

            return GetCombinations(6);
        }

        private long GetCombinations(long target)
        {
            long combinations = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                long currentNum = numbers[i];
                if (currentNum + 4 > target)
                {
                    if (currentNum < target)
                    {
                        combinations += GetCombinations(currentNum);
                    }
                    else
                    {
                        break;
                    }
                }
                
            }

            return combinations;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class XmasDecoder
    {
        private long[] numbers;

        public XmasDecoder()
        {
            LoadData();
        }

        public void LoadData()
        {
            numbers = System.IO.File.ReadAllLines(@"Challenges\files\dayninedata.txt").Select(long.Parse).ToArray();

        }

        public long FindFirstInvalidNumber()
        {
            int previousCount = 25;
            List<long> previousInts= numbers.Take(previousCount).ToList();
            int lineNumber = previousCount;
            long currentNumber = numbers[lineNumber];
            while ( lineNumber < numbers.Length)
            {
                
                bool valid = false;
                for (int queueIndex = 0; queueIndex < previousInts.Count - 1 && !valid; queueIndex++)
                {
                    for (int indexToAdd = queueIndex + 1; indexToAdd < previousInts.Count; indexToAdd++)
                    {
                        long sum = previousInts[queueIndex] + previousInts[indexToAdd];
                        if (sum == currentNumber)
                        {
                            valid = true;
                            break;
                        }
                    }
                }

                if (!valid) break;
                //drop first number, add next number to queue
                previousInts.RemoveAt(0);
                previousInts.Add(currentNumber);
                lineNumber++;
                currentNumber = numbers[lineNumber];
            }
            return currentNumber;
        }

        public long GetSumOfHighestAndLowestNumbersFromContiguousSetSummingTo(long expectedSum)
        {
            List<long> set = numbers.Take(2).ToList();
            bool found = false;
            int lineNo = 2;
            while (!found && lineNo < numbers.Length)
            {
                long setSum = set.Sum();
                if (setSum == expectedSum)
                {
                    found = true;
                    break;
                }
                else if (setSum > expectedSum)
                {
                    //set has exceeded our some, start again from the second number in our current set
                    lineNo -= set.Count-1;
                    set = numbers.Skip(lineNo).Take(2).ToList();
                    lineNo+=2;
                }
                else
                {
                    set.Add(numbers[lineNo]);
                    lineNo++;
                }
                
            }

            
            return set.Min() + set.Max();
        }

        
    }
}

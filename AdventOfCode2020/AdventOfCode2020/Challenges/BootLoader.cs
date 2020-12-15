using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class BootLoader
    {
        private string[] lines=null;
        private List<int> instructionExecutionLog = new List<int>();
        public BootLoader()
        {
            LoadData();
        }
        public void LoadData()
        {
            lines = System.IO.File.ReadAllLines(@"Challenges\files\daysevendata.txt");

            foreach (var line in lines)
            {
              instructionExecutionLog.Add(0);
            }
        }

        public int GetAccumulatorValueWhenInfiniteLoopHit()
        {
            int acc = 0;
            int lineNo = 0;
            while (lineNo < instructionExecutionLog.Count)
            {
                var instruction = lines[lineNo];
                instructionExecutionLog[lineNo]++;
                if (instruction.StartsWith("nop "))
                {
                    lineNo++;
                }
                else if (instruction.StartsWith("acc "))
                {
                    int add = int.Parse(instruction.Substring(3));
                    acc += add;
                }
                else if (instruction.StartsWith("jmp "))
                {
                    int add = int.Parse(instruction.Substring(3));
                    lineNo += add;
                    if (instructionExecutionLog[lineNo] != 0)
                    {
                        break;
                    }
                }
            }
            return acc;
        }
    }
}

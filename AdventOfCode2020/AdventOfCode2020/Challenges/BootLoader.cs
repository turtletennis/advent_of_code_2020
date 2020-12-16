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
            lines = System.IO.File.ReadAllLines(@"Challenges\files\dayeightdata.txt");
            instructionExecutionLog = GetInitialisedLog(lines.Length);
        }

        private static List<int> GetInitialisedLog(int count)
        {
            var executionLog=new List<int>();
            for (int i = 0; i < count; i++)
            {
                executionLog.Add(0);
            }

            return executionLog;
        }

        public int GetAccumulatorValueWhenInfiniteLoopHit()
        {
            int acc = 0;
            int lineNo = 0;
            while (lineNo < instructionExecutionLog.Count)
            {
                var instruction = lines[lineNo];
                if (instructionExecutionLog[lineNo] != 0)
                {
                    break;
                }
                instructionExecutionLog[lineNo]++;
                if (instruction.StartsWith("nop "))
                {
                    lineNo++;
                }
                else if (instruction.StartsWith("acc "))
                {
                    int add = int.Parse(instruction.Substring(3));
                    acc += add;
                    lineNo++;
                }
                else if (instruction.StartsWith("jmp "))
                {
                    int add = int.Parse(instruction.Substring(3));
                    lineNo += add;
                    
                }
            }
            return acc;
        }

        public int GetAccumulatorValueFromFixedProgram()
        {
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("nop") || lines[i].StartsWith("jmp"))
                {
                    string[] newProgram = (string[]) lines.Clone();
                    if (newProgram[i].StartsWith("nop"))
                    {
                        //this program would create an infinite loop, skip
                        if(newProgram[i]=="nop +0") continue;
                        string newInstruction = newProgram[i].Replace("nop", "jmp");
                        int offset = int.Parse(newInstruction.Substring(3));
                        
                        //this program either goes too far forwards, too far backwards or puts us in an infinite loop, skip
                        if(i+offset>lines.Length+1 || i+offset < 1) continue;

                        newProgram[i] = newInstruction;
                    }
                    else
                    {
                        newProgram[i] = newProgram[i].Replace("jmp", "nop");
                    }

                    int? accValue = GetAccumulatorValueIfProgramFinishes(newProgram);
                    if (accValue != null)
                    {
                        return accValue.Value;
                    }
                }
            }
            throw new Exception("Failed to find valid program");
        }

        private int? GetAccumulatorValueIfProgramFinishes(string[] programInstructions)
        {
            int acc = 0;
            int lineNo = 0;
            List<int> programExecutionLog=GetInitialisedLog(programInstructions.Length);
            
            while (lineNo < programInstructions.Length)
            {
                var instruction = programInstructions[lineNo];
                if (lineNo == programInstructions.Length)
                {
                    break;
                }

                if (programExecutionLog[lineNo] != 0)
                {
                    //program stuck in a loop
                    return null;
                }
                programExecutionLog[lineNo]++;
                if (instruction.StartsWith("nop "))
                {
                    lineNo++;
                }
                else if (instruction.StartsWith("acc "))
                {
                    int add = int.Parse(instruction.Substring(3));
                    acc += add;
                    lineNo++;
                }
                else if (instruction.StartsWith("jmp "))
                {
                    int add = int.Parse(instruction.Substring(3));
                    lineNo += add;

                }
            }

            return acc;
        }
    }
}

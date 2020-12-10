using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class Trees
    {
        private string[] lines;

        public Trees()
        {
            LoadData();
        }

        public void LoadData()
        {
            lines = System.IO.File.ReadAllLines(@"Challenges\files\daythreedata.txt");
            
        }

        private char treeChar = '#';
        public int GetTreeCount(int downRate, int rightRate)
        {
            int trees = 0;
            int x = 0;
            int y = 0;
            while(y<lines.Length)
            {
                char[] currentLine = lines[y].ToCharArray();
                //wrap, pattern repeats on x
                x = x % currentLine.Length;
                if (currentLine[x] == treeChar)
                {
                    trees++;
                }
                y += downRate;
                x += rightRate;
            }

            return trees;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class SeatPartitioning
    {
        private List<string> rowStrings = new List<string>();
        private List<string> columnStrings = new List<string>();
        
        public SeatPartitioning()
        {
           LoadData(); 
           
        }

        private void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Challenges\files\dayfivedata.txt");
            foreach (var line in lines)
            {
                rowStrings.Add(line.Substring(0,7));
                columnStrings.Add(line.Substring(7, 3));
            }
        }

        public int GetMaxSeatId()
        {
            int maxId = 0;
            for (int i = 0; i < rowStrings.Count; i++)
            {
                int row = SeatToInt(rowStrings[i]);
                int column = SeatToInt(columnStrings[i]);
                int id = row * 8 + column;
                maxId = maxId > id ? maxId : id;
            }
            return maxId;
        }

        private int SeatToInt(string seatRowOrColumn)
        {
            string bits = "";
            foreach (var letter in seatRowOrColumn)
            {
                if (letter == 'F' || letter == 'L')
                {
                    bits =  bits+ "0";
                }
                else
                {
                    bits = bits + "1";
                }
            }

            int number = Convert.ToInt32(bits,2);
            return number;

        }

        
    }
}

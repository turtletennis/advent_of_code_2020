using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class Questions
    {
        public Questions()
        {
            LoadData();
        }

        List<HashSet<char>> surveyYesAnswersPerGroup = new List<HashSet<char>>();
        public void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Challenges\files\daysixdata.txt");
            surveyYesAnswersPerGroup.Add(new HashSet<char>());
            foreach (var line in lines)
            {

                if (line != "")
                {
                    foreach (char question in line)
                    {
                        surveyYesAnswersPerGroup[surveyYesAnswersPerGroup.Count-1].Add(question);
                    }
                }
                else
                {
                    surveyYesAnswersPerGroup.Add(new HashSet<char>());
                    
                }
            }
        }

        public int GetTotalGroupYesCount()
        {
            int yesCount = 0;
            foreach (var yesquestions in surveyYesAnswersPerGroup)
            {
                yesCount += yesquestions.Count;
            }

            return yesCount;
        }

    }
}

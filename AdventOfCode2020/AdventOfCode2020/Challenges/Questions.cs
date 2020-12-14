using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<List<char[]>> groupMemberYesAnswers = new List<List<char[]>>();
        public void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Challenges\files\daysixdata.txt");
            surveyYesAnswersPerGroup.Add(new HashSet<char>());
            groupMemberYesAnswers.Add(new List<char[]>());
            foreach (var line in lines)
            {

                if (line != "")
                {
                    groupMemberYesAnswers[^1].Add(line.ToCharArray());
                    foreach (char question in line)
                    {
                        surveyYesAnswersPerGroup[^1].Add(question);
                    }
                }
                else
                {
                    surveyYesAnswersPerGroup.Add(new HashSet<char>());
                    groupMemberYesAnswers.Add(new List<char[]>());
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

        public int GetSumOfUnanimousYesCount()
        {
            int count = 0;
            foreach (var groupAnswers in groupMemberYesAnswers)
            {
                //we only need to iterate through the first person's answers
                foreach (var answer in groupAnswers[0])
                {
                    if (groupAnswers.All(a => a.Contains(answer)))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}

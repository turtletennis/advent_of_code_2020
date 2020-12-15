using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Challenges
{
    public class ColouredBags
    {
        public ColouredBags()
        {
            LoadData();
        }
        Dictionary<string,Dictionary<string,int>> bagContentsRules = new Dictionary<string, Dictionary<string, int>>();
        public void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Challenges\files\daysevendata.txt");
            
            foreach (var line in lines)
            {
                var match = Regex.Match(line, @"([a-zA-Z ]+) bags contain(?: ((\d+) ([a-zA-Z ]+)|no other) bags?[,.])+");


                string key = match.Groups[1].Value;
                if (match.Groups[2].Value != "no other ")
                {
                    var counts = match.Groups[3].Captures;
                    var containedColours = match.Groups[4].Captures;
                    Dictionary<string, int> containedBagRequirements = new Dictionary<string, int>();
                    for (int i = 0; i < containedColours.Count; i++)
                    {
                        containedBagRequirements.Add(containedColours[i].Value, int.Parse(counts[i].Value));
                    }

                    bagContentsRules.Add(key, containedBagRequirements);
                }
                else
                {
                    bagContentsRules.Add(key,new Dictionary<string, int>());
                }
            }
        }

        public int GetCountOfBagTypesContainingAColouredBag(string colour)
        {
            int count = 0;
            foreach (var bagContentsRule in bagContentsRules)
            {
                if (CountBagsContainingColouredBag(bagContentsRule.Key, colour) > 0)
                {
                    count++;
                }
            }
            return count;

        }

        private int CountBagsContainingColouredBag(string topLevelBagColour,string colour)
        {
            Dictionary<string, int> bagContents = bagContentsRules[topLevelBagColour];
            if (bagContents.Count == 0)
            {
                return 0;
            }
            if (bagContents.ContainsKey(colour))
            {
                return bagContents[colour];
            }
            else
            {
                int count = 0;
                foreach (var bagColour in bagContents.Keys)
                {
                    count += CountBagsContainingColouredBag(bagColour, colour);
                }

                return count;
            }
        }

        public int CountBagsWithinBagColour(string topLevelBagColour)
        {
            Dictionary<string, int> bagContents = bagContentsRules[topLevelBagColour];
            int totalCount = 0;
            if (bagContents.Count == 0)
            {
                return 0;
            }
            foreach (var bagContent in bagContents)
            {
                int nBags = bagContent.Value;
                int containedBagCount = CountBagsWithinBagColour(bagContent.Key);
                totalCount += nBags * (1 + containedBagCount);

            }
            return totalCount;
        }
    }
}

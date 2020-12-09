using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Challenges
{
    public class Passwords
    {
        List<KeyValuePair<string, string>> passwordRulesAndPasswordPairs;
        public Passwords()
        {
            passwordRulesAndPasswordPairs = new List<KeyValuePair<string, string>>();
            LoadData();
        }


        public void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Challenges\files\daytwodata.txt");
            foreach (var line in lines)
            {
                string[] split = line.Split(':');
                var rule = split[0].Trim();
                var password = split[1].Trim();
                passwordRulesAndPasswordPairs.Add(new KeyValuePair<string, string>(rule,password));
            }
        }

        public int GetValidPasswordCount()
        {
            int validCount = 0;
            foreach (var passwordRuleAndPassword in passwordRulesAndPasswordPairs)
            {
                if (VerifyPasswordAgainstRule(passwordRuleAndPassword.Key, passwordRuleAndPassword.Value))
                {
                    validCount++;
                }
            }

            return validCount;
        }

        public int GetValidPasswordRule2Count()
        {
            int validCount = 0;
            foreach (var passwordRuleAndPassword in passwordRulesAndPasswordPairs)
            {
                if (VerifyPasswordAgainstRule2(passwordRuleAndPassword.Key, passwordRuleAndPassword.Value))
                {
                    validCount++;
                }
            }

            return validCount;
        }

        public bool VerifyPasswordAgainstRule(string rule, string password)
        {
            int dashIndex = rule.IndexOf("-");
            int firstSpaceIndex = rule.IndexOf(" ");
            int minChars = int.Parse(rule.Substring(0,  dashIndex));
            int maxChars = int.Parse(rule.Substring(dashIndex+1,firstSpaceIndex-dashIndex));
            char checkChar = rule[firstSpaceIndex+1];
            int actualCount = password.ToCharArray().Count(c => c == checkChar);
            return actualCount >= minChars && actualCount <= maxChars;
        }

        public bool VerifyPasswordAgainstRule2(string rule, string password)
        {
            int dashIndex = rule.IndexOf("-");
            int firstSpaceIndex = rule.IndexOf(" ");
            int firstIndex = int.Parse(rule.Substring(0, dashIndex)) - 1;
            int secondIndex = int.Parse(rule.Substring(dashIndex + 1, firstSpaceIndex - dashIndex)) - 1;
            char checkChar = rule[firstSpaceIndex + 1];
            bool firstMatches = password[firstIndex] == checkChar;
            bool secondMatches = password[secondIndex] == checkChar;

            return firstMatches ^ secondMatches;
        }
    }
}

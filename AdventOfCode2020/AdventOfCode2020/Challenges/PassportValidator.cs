using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Challenges
{
    public class PassportValidator
    {
        List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();

        public PassportValidator()
        {
            LoadData();
        }

        public void LoadData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Challenges\files\dayfourdata.txt");
            Dictionary<string, string> passport = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                
                if (line != "")
                {
                    string[] fields = line.Split(' ');
                    
                    foreach (var field in fields)
                    {
                        string[] keyValue = field.Split(":");
                        passport.Add(keyValue[0], keyValue[1]);
                    }
                }
                else
                {
                    passports.Add(passport);
                    passport = new Dictionary<string, string>();
                }
            }

            if (lines[lines.Length-1] != "")
            {
                passports.Add(passport);
            }
        }

        public int CountValidPassports(List<string> requiredFields)
        {
            int validCount = 0;
            foreach (var passport in passports)
            {
                if (ValidatePassport(passport,requiredFields))
                {
                    validCount++;
                }
                else
                {
                    Console.WriteLine("Invalid passport: "+passport.ToString());
                }
            }

            return validCount;
        }

        public bool ValidatePassport(Dictionary<string, string> passport, List<string> requiredFields)
        {
            bool valid = true;
            foreach (var requiredField in requiredFields)
            {
                if (!passport.ContainsKey(requiredField))
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }
    }
}

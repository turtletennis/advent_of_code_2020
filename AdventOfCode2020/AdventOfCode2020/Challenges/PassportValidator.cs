using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public int CountValidPassports(List<string> requiredFields,bool validateFields)
        {
            int validCount = 0;
            foreach (var passport in passports)
            {
                if (ValidatePassport(passport,requiredFields,validateFields))
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

        public bool ValidatePassport(Dictionary<string, string> passport, List<string> requiredFields,bool validateFields)
        {
            bool valid = true;
            foreach (var requiredField in requiredFields)
            {
                if (!passport.ContainsKey(requiredField))
                {
                    valid = false;
                    break;
                }
                else
                {
                    if (validateFields)
                    {
                        if (!PassportFieldIsValid(requiredField,passport[requiredField]))
                        {
                            valid = false;
                            break;
                        }
                    }
                }
            }

            return valid;
        }

        private string[] validEyeColours = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
        private bool PassportFieldIsValid(string fieldName, string fieldValue)
        {
            bool valid = true;
            int year = 0;
            switch (fieldName)
            {
                case "byr":
                    int.TryParse(fieldValue, out year);
                    valid = year >= 1920 && year <= 2002;
                    break;
                case "iyr":
                    int.TryParse(fieldValue, out year);
                    valid = year >= 2010 && year <= 2020;
                    break;
                case "eyr":
                    int.TryParse(fieldValue, out year);
                    valid = year >= 2020 && year <= 2030;
                    break;
                case "hgt":
                    string suffix = new string(fieldValue.TakeLast(2).ToArray());
                    string prefix = Regex.Match(fieldValue, @"^\d+").Value;
                    int height = 0;
                    if (suffix == "cm")
                    {
                        int.TryParse(prefix, out height);
                        valid = height >= 150 && height <= 193;
                    }
                    else if(suffix=="in")
                    {
                        int.TryParse(prefix, out height);
                        valid = height >= 59 && height <= 76;
                    }
                    else
                    {
                        valid = false;
                    }
                    break;
                case "hcl":
                    valid = Regex.Match(fieldValue, @"^#[A-Za-z0-9]+$").Success;
                    break;
                case "ecl":
                    valid = validEyeColours.Contains(fieldValue);
                    break;
                case "pid":
                    valid = Regex.Match(fieldValue, @"^[0-9]{9}$").Success;
                    break;
            }

            return valid;
        }
    }
}

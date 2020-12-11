using System;
using System.Collections.Generic;
using AdventOfCode2020.Challenges;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var expenses = new Expenses();
            long result = expenses.GetDay1ChallengeResult();
            Console.WriteLine("Day one part one challenge result= "+result);
            result = expenses.GetDay1Part2ChallengeResult();
            Console.WriteLine("Day one part two challenge result= " + result);
            var passwords = new Passwords();
            result = passwords.GetValidPasswordCount();
            Console.WriteLine("Day two part one challenge result= " + result);
            result = passwords.GetValidPasswordRule2Count();
            Console.WriteLine("Day two part two challenge result= " + result);
            Trees trees = new Trees();
            result = trees.GetTreeCount(1, 3);
            Console.WriteLine("Day three part one challenge result= " + result);
            var a = trees.GetTreeCount(1, 1);
            var b = result;
            var c = trees.GetTreeCount(1, 5);
            var d = trees.GetTreeCount(1, 7);
            var e = trees.GetTreeCount(2, 1);
            result = a * b * c * d * e;
            Console.WriteLine("Day three part two challenge result= " + result);
            List<string> requiredPassportFields = new List<string>(new string[]{ "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"});
            PassportValidator passports = new PassportValidator();
            result = passports.CountValidPassports(requiredPassportFields);
            Console.WriteLine("Day four part one challenge result= " + result);
        }
    }
}

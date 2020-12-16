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
            result = passports.CountValidPassports(requiredPassportFields,false);
            Console.WriteLine("Day four part one challenge result= " + result);
            result = passports.CountValidPassports(requiredPassportFields, true);
            Console.WriteLine("Day four part two challenge result= " + result);
            SeatPartitioning seatPartitioning = new SeatPartitioning();
            result = seatPartitioning.GetMaxSeatId();
            Console.WriteLine("Day five part one challenge result= " + result);
            result = seatPartitioning.GetMySeatId();
            Console.WriteLine("Day five part two challenge result= " + result);
            Questions questions = new Questions();
            result = questions.GetTotalGroupYesCount();
            Console.WriteLine("Day six part one challenge result= " + result);
            result = questions.GetSumOfUnanimousYesCount();
            Console.WriteLine("Day six part two challenge result= " + result);
            ColouredBags colouredBags = new ColouredBags();
            result = colouredBags.GetCountOfBagTypesContainingAColouredBag("shiny gold");
            Console.WriteLine("Day seven part one challenge result= " + result);
            result = colouredBags.CountBagsWithinBagColour("shiny gold");
            Console.WriteLine("Day seven part two challenge result= " + result);
            BootLoader bootLoader = new BootLoader();
            result = bootLoader.GetAccumulatorValueWhenInfiniteLoopHit();
            Console.WriteLine("Day eight part one challenge result= " + result);
            result = bootLoader.GetAccumulatorValueFromFixedProgram();
            Console.WriteLine("Day eight part two challenge result= " + result);
            XmasDecoder xmasDecoder = new XmasDecoder();
            result = xmasDecoder.FindFirstInvalidNumber();
            Console.WriteLine("Day nine part one challenge result= " + result);
            long minMaxSum = xmasDecoder.GetSumOfHighestAndLowestNumbersFromContiguousSetSummingTo(result);
            Console.WriteLine("Day nine part two challenge result= " + minMaxSum);
        }
    }
}

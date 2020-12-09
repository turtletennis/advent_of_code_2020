using System;
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
            Console.WriteLine("Day three part one challenge result= " + result);
            result = passwords.GetValidPasswordRule2Count();
            Console.WriteLine("Day three part two challenge result= " + result);
        }
    }
}

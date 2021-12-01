using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day04
{
    public class Day04B : Day04A
    {
        private static readonly HashSet<string> EyeColor = new HashSet<string>
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };
        
        private static readonly HashSet<char> HexChar = new HashSet<char>(
            "0123456789abcdef");
        
        protected override bool IsValidPassport(IDictionary<string, string> passport)
        {
            return base.IsValidPassport(passport) &&
                IsBirthYearValid(passport) &&
                IsIssueYearValid(passport) && 
                IsExpirationYearValid(passport) &&
                IsHeightValid(passport) &&
                IsHairColorValid(passport) &&
                IsEyeColorValid(passport) &&
                IsPidValid(passport);
        }

        private static bool IsPidValid(IDictionary<string, string> passport)
        {
            var pid = passport["pid"];
            return pid.Length == 9 && int.TryParse(pid, out _);
        }

        private static bool IsEyeColorValid(IDictionary<string, string> passport)
        {
            return EyeColor.Contains(passport["ecl"]);
        }

        private static bool IsHairColorValid(IDictionary<string, string> passport)
        {
            var hcl = passport["hcl"];
            return hcl.Length == 7 && hcl.StartsWith("#") && hcl.Substring(1).All(c => HexChar.Contains(c));
        }

        private static bool IsHeightValid(IDictionary<string, string> passport)
        {
            var hgt = passport["hgt"];
            var isCm = hgt.EndsWith("cm");
            var isIn = hgt.EndsWith("in");
            if (!isCm && !isIn)
            {
                return false;
            }

            hgt = hgt.Substring(0, hgt.Length - 2);
            if (int.TryParse(hgt, out var hgtNum))
            {
                if (isCm && (hgtNum < 150 || hgtNum > 193))
                {
                    return false;
                } 
                
                if (isIn && (hgtNum < 59 || hgtNum > 76))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsExpirationYearValid(IDictionary<string, string> passport)
        {
            var isNumber = int.TryParse(passport["eyr"], out var expYear);
            return isNumber && expYear >= 2020 && expYear <= 2030;
        }

        private static bool IsIssueYearValid(IDictionary<string, string> passport)
        {
            var isNumber = int.TryParse(passport["iyr"], out var issueYear);
            return isNumber && issueYear >= 2010 && issueYear <= 2020;
        }

        private static bool IsBirthYearValid(IDictionary<string, string> passport)
        {
            var isNumber = int.TryParse(passport["byr"], out var birthYear);
            return isNumber && birthYear >= 1920 && birthYear <= 2020;
        }
    }
}
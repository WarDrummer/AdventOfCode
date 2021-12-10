using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day04
{
    public class Day04A : ProblemWithInput<Day04A>
    {
        public override string Solve()
        {
            var seed = ParserFactory.CreateSingleLineStringParser().GetData();
            using var md5Hasher = MD5.Create();
            
            for (var i = 0; i < int.MaxValue; i++)
            {
                var hashBytes = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes($"{seed}{i}"));
                if (hashBytes[0] == 0 && hashBytes[1] == 0 && (hashBytes[2] & 0xF0) == 0)
                    return $"{i}";
            }

            return "Unsolved";
        }
    }
}
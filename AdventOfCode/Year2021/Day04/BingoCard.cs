using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Year2021.Day04
{
    public class BingoCard
    {
        private readonly IDictionary<int, int> _b = new Dictionary<int, int>();
        public void Add(params IEnumerable<int>[] numbers)
        {
            var index = 0;
            foreach (var row in numbers)
            {
                foreach (var number in row)
                {
                    _b[index++] = number;
                }
            }
        }

        public bool IsWinner(ISet<int> drawn)
        {
            return 
                (drawn.Contains(_b[0]) && drawn.Contains(_b[1]) && drawn.Contains(_b[2]) && drawn.Contains(_b[3]) && drawn.Contains(_b[4])) ||
                (drawn.Contains(_b[5]) && drawn.Contains(_b[6]) && drawn.Contains(_b[7]) && drawn.Contains(_b[8]) && drawn.Contains(_b[9])) ||
                (drawn.Contains(_b[10]) && drawn.Contains(_b[11]) && drawn.Contains(_b[12]) && drawn.Contains(_b[13]) && drawn.Contains(_b[14])) ||
                (drawn.Contains(_b[15]) && drawn.Contains(_b[16]) && drawn.Contains(_b[17]) && drawn.Contains(_b[18]) && drawn.Contains(_b[19])) ||
                (drawn.Contains(_b[20]) && drawn.Contains(_b[21]) && drawn.Contains(_b[22]) && drawn.Contains(_b[23]) && drawn.Contains(_b[24])) ||
                (drawn.Contains(_b[0]) && drawn.Contains(_b[5]) && drawn.Contains(_b[10]) && drawn.Contains(_b[15]) && drawn.Contains(_b[20])) ||
                (drawn.Contains(_b[1]) && drawn.Contains(_b[6]) && drawn.Contains(_b[11]) && drawn.Contains(_b[16]) && drawn.Contains(_b[21])) ||
                (drawn.Contains(_b[2]) && drawn.Contains(_b[7]) && drawn.Contains(_b[12]) && drawn.Contains(_b[17]) && drawn.Contains(_b[22])) ||
                (drawn.Contains(_b[3]) && drawn.Contains(_b[8]) && drawn.Contains(_b[13]) && drawn.Contains(_b[18]) && drawn.Contains(_b[23])) ||
                (drawn.Contains(_b[4]) && drawn.Contains(_b[9]) && drawn.Contains(_b[14]) && drawn.Contains(_b[19]) && drawn.Contains(_b[24]));
        }

        public int GetScore(int lastCalled, ISet<int> f)
        {
            var unmarkedSum = 0;
            foreach (var kvp in _b)
            {
                if (!f.Contains(kvp.Value))
                {
                    unmarkedSum += kvp.Value;
                }
            }
            return lastCalled * unmarkedSum;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .Append(_b[0]).Append(' ')
                .Append(_b[1]).Append(' ')
                .Append(_b[2]).Append(' ')
                .Append(_b[3]).Append(' ')
                .Append(_b[4]).Append(' ')
                .AppendLine();
            
            sb
                .Append(_b[5]).Append(' ')
                .Append(_b[6]).Append(' ')
                .Append(_b[7]).Append(' ')
                .Append(_b[8]).Append(' ')
                .Append(_b[9]).Append(' ')
                .AppendLine();
            
            sb
                .Append(_b[10]).Append(' ')
                .Append(_b[11]).Append(' ')
                .Append(_b[12]).Append(' ')
                .Append(_b[13]).Append(' ')
                .Append(_b[14]).Append(' ')
                .AppendLine();
            
            sb
                .Append(_b[15]).Append(' ')
                .Append(_b[16]).Append(' ')
                .Append(_b[17]).Append(' ')
                .Append(_b[18]).Append(' ')
                .Append(_b[19]).Append(' ')
                .AppendLine();
            
            sb
                .Append(_b[20]).Append(' ')
                .Append(_b[21]).Append(' ')
                .Append(_b[22]).Append(' ')
                .Append(_b[23]).Append(' ')
                .Append(_b[24]).Append(' ')
                .AppendLine();
            
            return sb.ToString();
        }
    }
}
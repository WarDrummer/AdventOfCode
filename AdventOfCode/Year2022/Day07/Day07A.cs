using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day07
{
    public class Day07A : ProblemWithInput<Day07A>
    {
        public override string Solve()
        {
            var pathSize = GetPathSizes();

            ulong result = 0L;
            foreach (var kvp in pathSize)
            {
                if (kvp.Value <= 100000)
                {
                    result += kvp.Value;
                }
            }
            
            return result.ToString();
        }

        protected Dictionary<string, ulong> GetPathSizes()
        {
            var path = new Stack<string>();
            path.Push(".");

            var pathSize = new Dictionary<string, ulong>();

            var lines = ParserFactory.CreateMultiLineStringParser().GetData();
            foreach (var line in lines)
            {
                if (line[0] == '$') // cmd
                {
                    if (line[2] == 'c') // cd
                    {
                        if (line[5] == '/') // goto root
                        {
                            path.Clear();
                            path.Push(".");
                        }
                        else if (line[5] == '.') // back one dir
                        {
                            if (path.Count > 1)
                            {
                                path.Pop();
                            }
                        }
                        else // change dir
                        {
                            path.Push(line.Substring(5));
                        }
                    }
                }
                else if (char.IsDigit(line[0]))
                {
                    var folders = path.ToArray();
                    var pathName = "";
                    var fileSize = ulong.Parse(line.Split(' ')[0]);
                    for (var i = folders.Length - 1; i >= 0; i--)
                    {
                        pathName += $"{folders[i]}/";
                        if (!pathSize.ContainsKey(pathName))
                        {
                            pathSize[pathName] = 0;
                        }

                        pathSize[pathName] += fileSize;
                    }
                }
            }

            return pathSize;
        }
    }
}
using System;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day09
{
    public class Day09A : ProblemWithInput<Day09A>
    {
        private class Node
        {
            public Node Previous { get; set; }
            public Node Next { get; set; }
            public ulong? Value { get; set; }

            public Node(ulong? value)
            {
                Value = value;
            }
        }
        
        public override string Solve()
        {
            var data = ParserFactory.CreateSingleLineStringParser().GetData().ToCharArray();
            var head = new Node(null);
            var current = head;

            var isEmpty = false;
            ulong id = 0;
            foreach (var c in data)
            {
                if (!isEmpty)
                {
                    for (var j = 0; j < c - '0'; j++)
                    {
                        var tmp = new Node(id);
                        current.Next = tmp;
                        tmp.Previous = current;
                        current = tmp;
                    }
                    id++;
                }
                else
                {
                    for (var j = 0; j < c - '0'; j++)
                    {
                        var tmp = new Node(null);
                        current.Next = tmp;
                        tmp.Previous = current;
                        current = tmp;
                    }
                }

                isEmpty = !isEmpty;
            }
            
            head = head.Next; // get rid of start node
            var tail = current;

            current = head;
            while (tail != current)
            {
                while (current.Value != null)
                {
                    current = current.Next;
                }
                
                while (tail.Value == null)
                {
                    tail = tail.Previous;
                    if (current == tail)
                    {
                        break;
                    }
                }
                
                if (current == tail)
                {
                    break;
                }
                
                current.Value = tail.Value;
                tail.Value = null;
                tail = tail.Previous;
                current = current.Next;
            }
            
            // current = head;
            // while (current != null)
            // {
            //     Console.Write(current.Value == -1 ? ".": current.Value.ToString());
            //     current = current.Next;
            // }
            // Console.WriteLine();

            ulong checksum = 0;
            ulong position = 0;
            current = head;
            while (current.Value != null)
            {
                checksum += position * current.Value ?? 0;
                position++;
                current = current.Next;
            }
            
            return checksum.ToString();
        }
    }
}
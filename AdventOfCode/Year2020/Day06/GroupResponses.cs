using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day06
{
    public class GroupResponses
    {
        private readonly Dictionary<char, int> _responses = new Dictionary<char, int>();
        private int _numberOfResponders;
        
        public void AddResponses(string responses)
        {
            _numberOfResponders++;
            foreach (var response in responses)
            {
                if (!_responses.ContainsKey(response))
                {
                    _responses[response] = 0;
                }

                _responses[response]++;
            }
        }

        public int GetUniqueResponseCount()
        {
            return _responses.Keys.Count;
        }
        
        public int GetConsensusCount()
        {
            return _responses.Count(kvp => kvp.Value == _numberOfResponders);
        }
    }
}
namespace AdventOfCode.Year2020.Day02
{
    public class PasswordPolicyEnforcer
    {
        public int Min { get; }
        public int Max { get; }
        public char Pattern { get; }
        public string Password { get; }

        public PasswordPolicyEnforcer(int min, int max, string pattern, string password)
        {
            Min = min;
            Max = max;
            Pattern = pattern[0];
            Password = password;
        }

        public bool IsValid()
        {
            var counts = new int[256];
            foreach (var c in Password)
            {
                counts[c]++;
            }

            return counts[Pattern] >= Min && counts[Pattern] <= Max;
        }
    }
}
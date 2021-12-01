namespace AdventOfCode.Year2020.Day02
{
    public class PasswordPolicyEnforcerEx
    {
        private int Min { get; }
        private int Max { get; }
        private char Pattern { get; }
        private string Password { get; }

        public PasswordPolicyEnforcerEx(int min, int max, string pattern, string password)
        {
            Min = min;
            Max = max;
            Pattern = pattern[0];
            Password = password;
        }

        public bool IsValid()
        {
            var count = 0;
            if (Password[Min - 1] == Pattern)
            {
                count++;
            }

            if (Password[Max - 1] == Pattern)
            {
                count++;
            }

            return count == 1;
        }
    }
}
public class Solution
{
    private Dictionary<(int, int), bool> memo = new Dictionary<(int, int), bool>();

    public bool IsMatch(string s, string p)
    {
        return MatchHelper(s, p, 0, 0);
    }

    private bool MatchHelper(string s, string p, int i, int j)
    {
        // If the result is already in the memo, return it.
        if (memo.ContainsKey((i, j)))
        {
            return memo[(i, j)];
        }

        // If we've reached the end of the pattern, check if we've also reached the end of the string.
        if (j == p.Length)
        {
            return i == s.Length;
        }

        // Check if the current characters match or if the pattern has a '.'
        bool firstMatch = i < s.Length && (s[i] == p[j] || p[j] == '.');

        bool result;

        // If the next character in the pattern is '*'
        if (j + 1 < p.Length && p[j + 1] == '*')
        {
            result = MatchHelper(s, p, i, j + 2) || (firstMatch && MatchHelper(s, p, i + 1, j));
        }
        else
        {
            result = firstMatch && MatchHelper(s, p, i + 1, j + 1);
        }

        // Store the result in the memo dictionary
        memo[(i, j)] = result;
        return result;
    }
}
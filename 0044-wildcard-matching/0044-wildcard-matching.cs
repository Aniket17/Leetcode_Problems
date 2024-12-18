public class Solution {
    Dictionary<(int, int), bool> memo;

    public bool IsMatch(string s, string p) {
        memo = new();
        return IsMatchUtil(s, p, 0, 0);
    }

    private bool IsMatchUtil(string s, string p, int i, int j) {
        // Base cases
        if (j == p.Length)
            return i == s.Length;

        if (i == s.Length)
            return p.Skip(j).All(c => c == '*');

        // Check memoization
        if (memo.ContainsKey((i, j)))
            return memo[(i, j)];

        // Current character match or '?'
        bool currMatch = (s[i] == p[j]) || (p[j] == '?');

        if (p[j] == '*') {
            // '*' matches zero or more characters
            return memo[(i, j)] = IsMatchUtil(s, p, i + 1, j) || IsMatchUtil(s, p, i, j + 1);
        }

        return memo[(i, j)] = currMatch && IsMatchUtil(s, p, i + 1, j + 1);
    }
}
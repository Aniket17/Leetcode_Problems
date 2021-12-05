public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1) return s;

        StringBuilder sb = new StringBuilder();
        int n = s.Length;
        int cycleLen = 2 * numRows - 2;

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j + i < n; j += cycleLen) {
                sb.Append(s[j + i]);
                if (i != 0 && i != numRows - 1 && j + cycleLen - i < n)
                    sb.Append(s[j + cycleLen - i]);
            }
        }
        return sb.ToString();
    }
}
/*
"PAYPALISHIRING"
5

// diag = numRows - 2
*/
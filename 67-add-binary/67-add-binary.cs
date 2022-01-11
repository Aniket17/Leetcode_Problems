public class Solution {
    public string AddBinary(string a, string b) {
        int n = a.Length, m = b.Length;
        if (n < m) return AddBinary(b, a);
        int L = Math.Max(n, m);

        StringBuilder sb = new StringBuilder();
        int carry = 0, j = m - 1;
        for(int i = L - 1; i > -1; --i) {
          if (a[i] == '1') ++carry;
          if (j > -1 && b[j--] == '1') ++carry;

          if (carry % 2 == 1) sb.Append('1');
          else sb.Append('0');

          carry /= 2;
        }
        if (carry == 1) sb.Append('1');

        return new String(sb.ToString().Reverse().ToArray());
    }
}

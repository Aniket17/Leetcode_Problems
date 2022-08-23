public class Solution {
    public bool ConfusingNumber(int n) {
        var map = new Dictionary<int, int>(){{0,0},{1,1},{6,9},{8,8},{9,6}};
        var s = n.ToString();
        var rotated = new StringBuilder();
        for(int i = 0; i < s.Length; i++){
            var ch = (int)s[i]-'0';
            if(!map.ContainsKey(ch)) return false;
            rotated.Append(map[ch]);
        }
        return new String(rotated.ToString().Reverse().ToArray()) != s;
    }
}
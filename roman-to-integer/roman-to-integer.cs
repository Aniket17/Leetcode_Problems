public class Solution {
    public int RomanToInt(string s) {
        var map = new Dictionary<char, int>();
        map.Add('I', 1);
        map.Add('V', 5);
        map.Add('X', 10);
        map.Add('L', 50);
        map.Add('C', 100);
        map.Add('D', 500);
        map.Add('M', 1000);
        
        var beforeMap = new Dictionary<char, HashSet<char>>();
        beforeMap.Add('I', new HashSet<char>(){'V', 'X'});
        beforeMap.Add('X', new HashSet<char>(){'L', 'C'});
        beforeMap.Add('C', new HashSet<char>(){'D', 'M'});
        
        var len = s.Length;
        var lastChar = s[len - 1];
        var ans = map[lastChar];
        // Console.Write("+"+map[lastChar]);
        for(int i = len - 2; i >= 0; i--){
            if (beforeMap.ContainsKey(s[i]) && beforeMap[s[i]].Contains(lastChar)){
                // subtract
                // Console.Write("-"+map[s[i]]);
                ans -= map[s[i]];
            } else {
                // Console.Write("+"+map[s[i]]);
                 ans += map[s[i]];
            }
            lastChar = s[i];
        }
        return ans;
    }
}

/*
MCMXCIV

+5
-1
+100
-10
+1000
-100
+1000
*/
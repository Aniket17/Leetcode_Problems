public class Solution {
    Dictionary<int, int> map;
    public IList<string> FindStrobogrammatic(int n) {
        if(n == 1) return new List<string>(){"1", "0","8"};
        var ans = new List<string>();
        if(n == 0) return ans;

        map = new Dictionary<int, int>();
        map.Add(0,0);
        map.Add(1,1);
        map.Add(6,9);
        map.Add(9,6);
        map.Add(8,8);
        
        Backtrack("", 0, n, ans);
        
        return ans;
    }

    void Backtrack(string s, int idx, int n, List<string> ans){
        if(idx == n){
            ans.Add(s);
            return;
        }
        char[] options;
        if(idx == 0){
            options = new char[]{'1', '6', '8', '9'};
            foreach(var o in options){
                Backtrack(s+o, idx+1, n, ans);
            }
            return;
        }
        if(idx < n/2){
            options = new char[]{'0', '1', '6', '8', '9'};
            foreach(var o in options){
                Backtrack(s+o, idx+1, n, ans);
            }
            return;
        }
        if(n % 2 == 1 && idx == n/2){
            options = new char[]{'0', '1', '8'};
            foreach(var o in options){
                Backtrack(s+o, idx+1, n, ans);
            }
            return;
        }

        var ch = s[n - idx - 1];
        Backtrack(s+map[ch - '0'], idx+1, n, ans);
    }
}
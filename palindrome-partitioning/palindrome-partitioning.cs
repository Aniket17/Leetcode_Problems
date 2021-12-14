public class Solution {
    public IList<IList<string>> Partition(string s) {
        var ans = new List<IList<string>>();
        var current = new List<string>();
        Solve(s, 0, current, ans);
        return ans;
    }
    
    void Solve(string s, int start, List<string> current, List<IList<string>> ans){
        if(start >= s.Length){
            ans.Add(current.ToList());
            return;
        }
        for(int pos = start; pos < s.Length; pos++){
            if(IsPalindrom(s, start, pos)){
                current.Add(s.Substring(start, pos - start + 1));
                Solve(s, pos + 1, current, ans);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
    
    bool IsPalindrom(string s, int left, int right){
        while(left < right){
            if(s[left++] != s[right--]) return false;
        }
        return true;
    }
    
    void GetPowersets(string s, int pos, string current, List<string> allSets){
        if(pos == s.Length){
            allSets.Add(current);
            return;
        }
        GetPowersets(s, pos + 1, current + s[pos], allSets);
        GetPowersets(s, pos + 1, current, allSets);
    }
    
}


/*
"anazkeka"
[a n a z k e k a]
[a n a z kek a]
[ana z kek a]
[ana z k e k a]
*/
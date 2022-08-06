public class Solution {
    public int ExpressiveWords(string s, string[] words) {
        var dups = GetDups(s); 
        var count = 0;
        foreach(var w in words){
            var wDups = GetDups(w);
            if(IsValid(s, w, dups, wDups)){
                count++;
            }
        }
        return count;
    }
    
    private bool IsValid(string s, string w, int[] sd, int[] wd){
        var i = s.Length - 1;
        var j = w.Length - 1;
        while(i >= 0 && j >= 0){
            if(s[i] != w[j]) return false;
            if(sd[i] < wd[j]){
                return false;
            }
            if(sd[i] == wd[j]){
                i -= sd[i];
                j -= wd[j];
                continue;
            }
            if(wd[j] == 1 && sd[i] < 3){
                return false;
            }
            
            i -= sd[i];
            j -= wd[j];
        }
        return i < 0 && j < 0;
    }
    
    private int[] GetDups(string s){
        var dups = new int[s.Length];
        Array.Fill(dups, 1);
        for(int i = 1; i < s.Length; i++){
            if(s[i] == s[i - 1]){
                dups[i] = 1 + dups[i - 1];
            }
        }
        return dups;
    }
}
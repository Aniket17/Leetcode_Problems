public class Solution {
    public int CompareVersion(string version1, string version2) {
        var sub1 = version1.Split(".").ToList();
        var sub2 = version2.Split(".").ToList();
        PadSmaller(sub1, sub2);
        
        for(int i = 0; i < sub1.Count; i++){
            var res = Compare(sub1[i], sub2[i]);
            if(res != 0){
                return res;
            }
        }
        return 0;
    }
    
    int Compare(string s, string t){
        s = StripZeros(s);
        t = StripZeros(t);
        var sbs = new StringBuilder(s);
        var sbt = new StringBuilder(t);
        PadSmaller(sbs, sbt);
        s = sbs.ToString();
        t = sbt.ToString();
        
        for(int i = 0; i < s.Length; i++){
            if(s[i] < t[i]){
                return -1;
            }
            if(s[i] > t[i]){
                return 1;
            }
        }
        return 0;
    }
    
    string StripZeros(string s){
        var i = 0;
        if(s.Length == 1) return s;
        while(i < s.Length && s[i] == '0'){
            i++;
        }
        return s.Substring(i);
    }
    
    void PadSmaller(List<string> s, List<string>t){
        if(s.Count == t.Count) return;
        
        if(s.Count < t.Count){
            PadSmaller(t, s);
        }
        
        var diff = s.Count - t.Count;
        while(diff-- > 0){
            t.Add("0");
        }
    }
    
    void PadSmaller(StringBuilder s, StringBuilder t){
        if(s.Length == t.Length) return;
        
        if(s.Length < t.Length){
            PadSmaller(t, s);
        }
        
        var diff = s.Length - t.Length;
        var pref = "";
        while(diff-- > 0){
            pref+="0";
        }
        var ts = t.ToString();
        t.Clear();
        t.Append(pref).Append(ts);
    }
    
}
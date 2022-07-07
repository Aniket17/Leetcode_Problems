/*
1.1.1
"1.001.0001"
"1.100.10.1"
*/

public class Solution {
    public int CompareVersion(string version1, string version2) {
        var v1 = version1.Split(".").Select(Clean).ToList();
        var v2 = version2.Split(".").Select(Clean).ToList();
        if(v1.Count > v2.Count){
            while(v1.Count > v2.Count){
                v2.Add("0");
            }
        }else{
            while(v2.Count > v1.Count){
                v1.Add("0");
            }
        }
        for(int i = 0; i < v1.Count; i++){
            var rev1 = int.Parse(v1[i]);
            var rev2 = int.Parse(v2[i]);
            if(rev1 > rev2){
                return 1;
            }else if(rev1 < rev2) return -1;
        }
        return 0;
    }
    
    public string Clean(string s){
        // remove leading zeros
        if(string.IsNullOrEmpty(s)) return "0";
        var cleaned = "";
        int i = 0;
        for(; i < s.Length; i++){
            if(s[i] == '0') continue;
            else break;
        }
        if(i == s.Length) return "0";
        cleaned = s.Substring(i, s.Length - i);
        return cleaned;
    }
}
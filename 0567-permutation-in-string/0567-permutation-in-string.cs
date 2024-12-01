public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var sorted1 = Sort(s1);
        for(int i = 0; i <= s2.Length - s1.Length; i++){
            if(sorted1.Equals(Sort(s2.Substring(i, s1.Length)))){
                return true;
            }
        }
        return false;
    }

    string Sort(string s){
        var t = s.ToArray();
        Array.Sort(t);
        return new string(t);
    }
}
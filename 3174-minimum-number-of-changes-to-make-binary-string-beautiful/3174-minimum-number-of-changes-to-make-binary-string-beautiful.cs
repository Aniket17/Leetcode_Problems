public class Solution {
    public int MinChanges(string s) {
        var edits = 0;
        for(int i = 0; i < s.Length; i+=2){
            if(s[i] != s[i+1]){
                edits++;
            }
        }
        return edits;
    }
}

/*
0000
0000
*/
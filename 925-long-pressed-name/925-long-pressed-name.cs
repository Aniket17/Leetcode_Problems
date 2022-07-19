public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        int i = 0, j = 0;
        if(typed.Length < name.Length) return false;
        int m = name.Length, n = typed.Length;
        
        while(i < m && j < n){
            if(name[i] == typed[j]){
                i++;
                j++;
            }else{
                while(j > 0 && j < n && typed[j] == typed[j - 1]){
                    j++;
                }
                if(j == n || typed[j] != name[i]) return false;
            }
        }
        if(i != m) return false;
        while(j < n){
            if(typed[j] != typed[j - 1]){
                return false;
            }
            j++;
        }
        return true;
    }
}

/*
two pointer approach
i points to real name
j points to typed
move j till it matches i
when j != i move i
when i moves and j != i damn!
*/
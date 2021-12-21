public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        if(name == typed) return true;
        if(typed.Length == 1) return name == typed;
        var j = typed.Length - 1;
        if(name[name.Length - 1] != typed[j]) return false;
        if(name[0] != typed[0]) return false;
        for(int i = name.Length - 1; i >= 0 ; i--){
            var ch = name[i];
            if(j < 0) return false;
            if(typed[j] != ch){
                while(j >= 0 && typed[j] == typed[j + 1]){
                    j--;
                }
                if(typed[j] != ch){
                    return false;
                }
            }
            j--; 
        }
        while(j > 0){
            if(typed[j] != typed[j - 1]) return false;
            j--;
        }
        return true;
    }
}
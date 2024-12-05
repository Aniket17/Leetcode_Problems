public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        var sb = new StringBuilder();
        var j = 0;
        for(int i = 0; i < s.Length; i++){
            //Console.WriteLine(j);
            if(j < spaces.Length && spaces[j] == i){
                //insert space
                sb.Append(" ");
                j++;
            }
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
}

/*  
0123456789...
s = Enjoy Your Coffee

012345
priyam => 1,2,3,1,2,3
p riyam
*/
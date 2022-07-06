/*
signed
trim
check for sign (default +)
read all consecutive digits
if nothing is there return 0
*/

public class Solution {
    public int MyAtoi(string s) {
        s = s.Trim();
        if(string.IsNullOrEmpty(s)) return 0;
        
        var set = new HashSet<char>();
        for(int i = 0; i <= 9; i++){
            set.Add((char) (i + 48));
        }
        
        var isPositive = true;
        var hasSign = false;
        var foundFirstDigit = false;
        var sb = new StringBuilder();
        for(int i = 0; i < s.Length; i++){
            var ch = s[i];
            if(!foundFirstDigit && !set.Contains(ch)){
                if(hasSign) return 0;
                if(ch == '-') {
                    isPositive = false;
                    hasSign = true;
                }
                else if(ch == '+') {
                    isPositive = true;
                    hasSign = true;
                }
                else return 0;
            }else if(!foundFirstDigit && set.Contains(ch)){
                if(ch == '0'){
                    hasSign = true;
                    continue;
                }
                foundFirstDigit = true;
                sb.Append(ch);
            }else if(foundFirstDigit && !set.Contains(ch)){
                break;
            }else if(foundFirstDigit && set.Contains(ch)){
                sb.Append(ch);
            }
        }
        var currentNum = sb.ToString();
        if(string.IsNullOrEmpty(currentNum)) return 0;
        //check out of bounds
        if(currentNum.Length > int.MaxValue.ToString().Length){
            return isPositive ? int.MaxValue : int.MinValue;
        }
       
        long longVal = long.Parse(currentNum) * (!isPositive ? -1 : +1);
        if(longVal >= int.MaxValue){
            return int.MaxValue;
        }else if(longVal <= int.MinValue){
            return int.MinValue;
        }else{
            return int.Parse(currentNum) * (!isPositive ? -1 : +1);
        }
    }
}
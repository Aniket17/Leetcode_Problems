/**
"42"
isFirstWhitespace = true;
currentNum = "42";
*/
public class Solution {
    public int MyAtoi(string s) {
        if(string.IsNullOrEmpty(s)) return 0;
        //traverse till first sign or non dig char
        var isFirstWhitespace = true;
        var currentNum = "";
        var isPositive = true;
        var hasSignChecked = false;
        var hasFirstNonZeroDigit = false;
        for(int i = 0; i < s.Length; i++){
            if(s[i] == ' '){
                if(isFirstWhitespace) continue;
                break;
            }
            if(!Char.IsDigit(s[i])){
                if(hasSignChecked){
                    break;
                }
                if(s[i] == '-'){
                    isPositive = false;
                    hasSignChecked = true;
                }else if(s[i] == '+'){
                    hasSignChecked = true;
                }else{
                    break;
                }
                isFirstWhitespace = false;
                continue;
            }
            if(isFirstWhitespace){
                isFirstWhitespace = false;
            }
            if(!hasSignChecked){
                hasSignChecked = true;
            }
            if(s[i] == '0' && !hasFirstNonZeroDigit){
                continue;
            }
            hasFirstNonZeroDigit = true;
            //s[i] is a digit.. append
            currentNum += s[i];
        }
        if(String.IsNullOrEmpty(currentNum)) return 0;
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

//ignore leading spaces and 0
//check the sign
//check first non-digit char
//
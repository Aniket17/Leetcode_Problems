public class Solution {
    public string IntToRoman(int num) {
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] symbols = { "M",  "CM", "D",  "CD", "C",  "XC", "L",
                             "XL", "X",  "IX", "V",  "IV", "I" };
        
        var sb = new StringBuilder();
        for(int i = 0; i < values.Length && num > 0; i++){
            while(num >= values[i]){
                sb.Append(symbols[i]);
                num -= values[i];
            }
        }
        return sb.ToString();
    }
}
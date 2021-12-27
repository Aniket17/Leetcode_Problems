public class Solution {
    public int FindComplement(int num) {
        var binary = Convert.ToString(num, 2);
        var ret = 0;
       
        for(int i = 0; i < binary.Length; i++){
            int bit = 1 - ((int)binary[i] - '0');
            if(bit == 1){
                ret = ret + (int)Math.Pow(2, binary.Length - i - 1);
            }
        }
        return ret;
    }
}

/*
XOR

0 ^ 0 => 1
1 ^ 1 => 1
0 ^ 1 => 0
1 ^ 0 => 0
*/
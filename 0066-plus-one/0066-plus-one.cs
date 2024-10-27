public class Solution {
    public int[] PlusOne(int[] digits) {
        //start from left to right
        //store the carry
        var n = digits.Length;
        var i = n - 1;
        var ans = new Stack<int>();
        var carry = 1;
        while(i >= 0){
            var curr = digits[i];
            var sum = curr + carry;
            ans.Push(sum % 10);
            carry = sum / 10;
            i--;
        }
        if(carry > 0){
            ans.Push(carry);
        }
        return ans.ToArray();
    }
}
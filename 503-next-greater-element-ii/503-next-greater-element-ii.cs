public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        var n = nums.Length;
        var stack = new Stack<int>();
        var result = new int[n];
        
        stack.Push(-1);
        for(int i = 2 * n - 1; i >= 0; i--){
            if(stack.Peek() == -1){
                result[i % n] = -1;
                stack.Push(i % n);
                continue;
            }
            while(stack.Peek() != -1 && nums[stack.Peek()] <= nums[i % n]){
                stack.Pop();
            }
            result[i % n] = stack.Peek() == -1 ? -1 : nums[stack.Peek()];
            stack.Push(i % n);
        }
        return result;
    }
}
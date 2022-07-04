/*
[1,3,4,2]



*/
public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var map = new Dictionary<int, int>();
        for(int i = 0; i < nums2.Length; i++){
            map[nums2[i]] = i;
        }
        var result = new int[nums1.Length];
        
        var stack = new Stack<int>();
        stack.Push(-1);
        var nextGreater = new int[nums2.Length];
        for(int i = nums2.Length - 1; i >= 0; i--){
            if(stack.Peek() == -1){
                //empty stack
                stack.Push(i);
                nextGreater[i] = -1;
                continue;
            }
            
            if(nums2[i] > nums2[stack.Peek()]){
                //remove smaller elements
                while(stack.Peek() != -1 && nums2[i] > nums2[stack.Peek()]){
                    stack.Pop();
                }
            }
            nextGreater[i] = stack.Peek();
            stack.Push(i);
        }
        
        for(int i = 0; i < nums1.Length; i++)
        {
            var pos = map[nums1[i]];
            result[i] = nextGreater[pos] == -1 ? -1 : nums2[nextGreater[pos]];
        }
        return result;
    }
}
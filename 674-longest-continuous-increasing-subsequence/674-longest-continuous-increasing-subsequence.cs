public class Solution {
    Dictionary<string, int> memo = new Dictionary<string, int>();
    public int FindLengthOfLCIS(int[] nums) {
        int max = 0;
        var localMax = 0;
        for(int i = 1; i < nums.Length; i++){
           if(nums[i - 1] < nums[i]){
               localMax++;
               max = Math.Max(localMax, max);
           }else{
               localMax = 0;
           }
        }
        return max + 1;
    }
    
    // private int LengthOfLCS(int[] arr1, int[] arr2, int i, int j){
    //     if(i >= arr1.Length || j >= arr2.Length) return 0;
    //     var key = $"{i},{j}";
    //     if(arr1[i] == arr2[j]){
    //         return memo[key] = 1 + LengthOfLCS(arr1, arr2, i + 1, j + 1);
    //     }
    //     return memo[key] = Math.Max(LengthOfLCS(arr1, arr2, i + 1, j), 
    //                                 LengthOfLCS(arr1, arr2, i, j + 1));
    // }
}
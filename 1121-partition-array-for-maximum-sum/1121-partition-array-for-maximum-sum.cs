public class Solution {
    int[] memo;
    public int MaxSumAfterPartitioning(int[] arr, int k) {
        memo = new int[arr.Length];
        Array.Fill(memo, -1);
        return GetSum(arr, k, 0);
    }

    int GetSum(int[] arr, int k, int start){
        if(start >= arr.Length) return 0;
        if(memo[start] != -1) return memo[start];
        //partition from start to start+k and return the max sum
        var max = 0;
        var maxSum = 0;
        for(int i = start; i < start + k && i < arr.Length; i++){
            max = Math.Max(arr[i], max);
            maxSum = Math.Max(maxSum, max * (i - start + 1) + GetSum(arr, k, i + 1));
        }
        return memo[start] = maxSum;
    }
}
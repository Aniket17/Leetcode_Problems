public class Solution {
    int[][] dp = new int[100005][];

    public int MinSwap(int[] nums1, int[] nums2) {
        var n = nums1.Length;
        return DFS(nums1, nums2, 0, n, -1, -1, 0);
    }
    
    
    int DFS(int[] nums1, int[] nums2, int i, int n, int prev1, int prev2, int swap)
    {
        if(i == n)
            return 0;
        if(dp[i] == null){
            dp[i] = new int[2]{-1,-1};
        }
        if(dp[i][swap] != -1)
            return dp[i][swap];
        
        int ans = int.MaxValue;
        
        // no swaps have been made
        
        if(nums1[i] > prev1 && nums2[i] > prev2)
        {
            ans = Math.Min(ans, DFS(nums1, nums2, i + 1, n, nums1[i], nums2[i], 0));
        }
        
        // swaps have been made
        
        if(nums1[i] > prev2 && nums2[i] > prev1)
        {
            ans = Math.Min(ans, 1 + DFS(nums1, nums2, i + 1, n, nums2[i], nums1[i], 1));
        }
        
        // store in dp
        return dp[i][swap] = ans;
    }
}

/*
[1,7,8,9,10]
[3,3,4,6,8]

1

*/
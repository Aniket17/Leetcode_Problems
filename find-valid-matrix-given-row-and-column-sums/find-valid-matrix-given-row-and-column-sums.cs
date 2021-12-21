public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        // chose min betwn i and j of sum
        // update the sum
        var rsum = rowSum;
        var csum = colSum;
        var m = rowSum.Length;
        var n = colSum.Length;
        var ans = new int[m][];
        for(int i = 0; i < m; i++){
            ans[i] = new int[n];
            for(int j = 0; j < n; j++){
                //decrease the sum of col and row by min
                var min = Math.Min(rsum[i], csum[j]);
                ans[i][j] = min;
                rsum[i] -= min;
                csum[j] -= min;
            }
        }
        return ans;
    }
}


/*
rowSum = [3,8], colSum = [4,7]

rowSum = [5,7,10], colSum = [8,6,8]

        8   6   8

5       5   0   0
7       3   4   0
10      0   2   8

*/
public class Solution {
    public int MaximalSquare(char[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var dp = new int[m,n];
        var max = 0;
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                dp[i,j] = matrix[i][j] - '0';
                if(dp[i,j] == 1){
                    max = 1;
                }
            }
        }
        for(int i = 1; i < m; i++){
            for(int j = 1; j < n; j++){
                if(dp[i,j] == 1){
                    var min = Math.Min(dp[i-1,j], dp[i,j-1]);
                    min = Math.Min(min, dp[i-1,j-1]);
                    if(min != 0){
                        dp[i,j] = 1 + min;
                        max = Math.Max(max, dp[i,j]);
                    }
                }
            }
        }
        return max*max;
    }
}
public class Solution {
    public int MaximalSquare(char[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        if (m == 0) return 0;

        int[,] dp = new int[m, n];
        int maxSideLength = 0;

        // Traverse the matrix to build the DP table
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == '1') {
                    if (i == 0 || j == 0) {
                        // Base case: first row or first column
                        dp[i, j] = 1;
                    } else {
                        // Fill dp table based on the minimum of top, left, and top-left neighbors
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                    }
                    // Update max side length
                    maxSideLength = Math.Max(maxSideLength, dp[i, j]);
                }
            }
        }

        // Return the area of the largest square
        return maxSideLength * maxSideLength;
    }
}

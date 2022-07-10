public class Solution {
    int[] memo;
    int[][] dirs = new int[4][]{
        new int[]{1,0},
        new int[]{-1,0},
        new int[]{0,1},
        new int[]{0,-1},
    };
    public int LongestIncreasingPath(int[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        memo = new int[m*n];
        Array.Fill(memo, -1);
        
        var max = int.MinValue;
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                memo[i * n + j] = Dfs(matrix, i, j);
                max = Math.Max(max, memo[i * n + j]);
            }
        }
        return 1 + max;
    }
    
    int Dfs(int[][] matrix, int i, int j){
        var m = matrix.Length;
        var n = matrix[0].Length;
        var key = i * n + j;
        var max = 0;
        if(memo[key] != -1){
            return memo[key];
        }
        foreach(var dir in dirs){
            var row = i + dir[0];
            var col = j + dir[1];
            if(row < 0 || col < 0 || row >= m || col >= n) continue;
            if(matrix[row][col] > matrix[i][j]){
                // found path
                var currPath = 1 + Dfs(matrix, row, col);
                max = Math.Max(max, currPath);
            }
        }
        return memo[key] = max;
    }
}

/*
[
[3,2,1],
[0,3,0],
[1,0,0]
]
*/
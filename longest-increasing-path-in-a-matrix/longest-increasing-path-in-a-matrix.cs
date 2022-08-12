public class Solution {
    int[][] dirs = new int[][]{
            new int[]{0,1},
            new int[]{1,0},
            new int[]{0,-1},
            new int[]{-1,0},
        };
    public int LongestIncreasingPath(int[][] matrix) {
        //backtrack + dfs
        //store the results
        //do it for each cell which is not in results
        var m = matrix.Length;
        var n = matrix[0].Length;
        var memo = new int[m*n];
        Array.Fill(memo, -1);
        var longest = -1;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                var path = Dfs(i, j, matrix, memo, new HashSet<int>());
                longest = Math.Max(longest, 1+path);
            }
        }
        
        return longest;
    }
    
    int Dfs(int i, int j, int[][] matrix, int[] memo, HashSet<int> seen){
        var m = matrix.Length;
        var n = matrix[0].Length;
        if(memo[i*n+j] != -1){
            return memo[i*n+j];
        }
        var longest = 0;
        foreach(var dir in dirs){
            var row = i + dir[0];
            var col = j + dir[1];
            if(IsValid(row, col, m, n, seen) && matrix[i][j] < matrix[row][col]){
                seen.Add(row * n + col);
                longest = Math.Max(longest, 1 + Dfs(row, col, matrix, memo, seen));
                seen.Remove(row * n + col);
            }
        }
        if(longest == 0){
            return 0;
        }
        return memo[i*n+j] = longest;
    }
    
    bool IsValid(int row, int col, int m, int n, HashSet<int> seen){
        if(row < 0 || row >= m || col < 0 || col >= n || seen.Contains(row*n+col)){
            return false;
        }
        return true;
    }
}
public class Solution {
    Dictionary<string, int> memo = new Dictionary<string, int>();
    public int MinPathSum(int[][] grid) {
        // go left , down
        // base case = i == m - 1 && j == n - 1
        var ans = GetPathSum(grid, 0, 0);
        return ans;
    }

    private int GetPathSum(int[][] grid, int i, int j){
        var m = grid.Length;
        var n = grid[0].Length;
        var key = $"{i},{j}";
        if(memo.ContainsKey(key)) return memo[key];
        if(i == m - 1 && j == n - 1){
            return grid[i][j];
        }
        if(i >= m || j >= n) return int.MaxValue;
        
        var rightSum = GetPathSum(grid, i, j + 1);
        var downSum = GetPathSum(grid, i + 1, j);
        var ans = Math.Min(rightSum, downSum);
        if(ans == int.MaxValue){
            return ans;
        }
        return memo[key] = grid[i][j] + Math.Min(rightSum, downSum);
    }
}
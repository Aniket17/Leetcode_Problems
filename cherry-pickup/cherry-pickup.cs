public class Solution{
    public int CherryPickup(int[][] grid){
        var dp = new Dictionary<string, int>();
        var ans = Solve(grid, 0, 0, 0, dp);
        return ans < 0 ? 0 : ans;
    }

    private int Solve(int[][] grid, int r1, int c1, int r2, Dictionary<string, int> dp){
        // base conditions
        var m = grid.Length;
        var n = grid[0].Length;

        int c2 = r1 + c1 - r2;

        if(r1 >= m || c1 >= n || r2 >= m || c2 >= n || grid[r1][c1] == -1 || grid[r2][c2] == -1){
            return int.MinValue;
        }

        if(r1 == m - 1 && c1 == n - 1){
            return grid[r1][c1];
        }
        var key = $"{r1},{c1}|{r2}";
        if(dp.ContainsKey(key)) return dp[key];

        // if on same pos
        int cherries = 0;
        if(r1 == r2 && c1 == c2){
            cherries += grid[r1][c1];
        }else{
            cherries += grid[r1][c1] + grid[r2][c2];
        }

        var f1 = Solve(grid, r1 + 1, c1, r2 + 1, dp);
        var f2 = Solve(grid, r1 + 1, c1, r2, dp);
        var f3 = Solve(grid, r1, c1 + 1, r2 + 1, dp);
        var f4 = Solve(grid, r1, c1 + 1, r2, dp);

        cherries += Math.Max(Math.Max(f1, f2), Math.Max(f3, f4));
        // if(sub > 0){
        //     cherries += sub;
        // }
        dp[key] = cherries;
        return cherries;
    }
}



public class Solution{
    public int CherryPickup(int[][] grid){
        var m = grid.Length;
        var n = grid[0].Length;
        int[,,] dp = new int[m, n, n];
        
        var ans = Solve(grid, 0, 0, n - 1, dp);
        return ans;
    }

    private int Solve(int[][] grid, int r1, int c1, int c2, int[,,] dp){
        // base conditions
        var m = grid.Length;
        var n = grid[0].Length;
        int r2 = r1;
        
        int cherries = 0;
        
        if(r1 == m){
            return 0;
        }
        if(c1 == c2){
            cherries = grid[r1][c1];
        }else{
            cherries = grid[r1][c1] + grid[r2][c2];
        }
        
        if(dp[r1,c1,c2] != 0) return dp[r1,c1,c2];
        
        int max = 0;
        
        for(int i = -1; i < 2; i++){
            for(int j = -1; j < 2; j++){
                var col1 = c1 + i;
                var col2 = c2 + j;
                if(0 <= col1 && col1 < n && 0 <= col2 && col2 < n){
                    max = Math.Max(max, Solve(grid, r1 + 1, col1, col2, dp));
                }
            }
        }
        
        cherries += max;
        dp[r1,c1,c2] = cherries;
        return cherries;
    }
}



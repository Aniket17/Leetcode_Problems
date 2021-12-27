public class Solution {
    Dictionary<string, int> memo = new Dictionary<string, int>();
    int m, n;
    int[][] grid;
    public int CherryPickup(int[][] grid) {
        m = grid.Length;
        n = grid[0].Length;
        this.grid = grid;
        
        return Dfs(0,0,n-1);
    }
    
    int Dfs(int row, int col, int rob){
        
        var key = $"{row},{col},{rob}";
        if(memo.ContainsKey(key)) return memo[key];
        
        if(row == m){
            return 0;
        }
        
        var cherries = col == rob ? grid[row][col] : grid[row][col] + grid[row][rob];
        var result = 0;
        for(int i = -1; i < 2; i++){
            for(int j = -1; j < 2; j++){
                var col1 = col + i;
                var col2 = rob + j;
                if(0 <= col1 && col1 < n && 0 <= col2 && col2 < n){
                    result = Math.Max(result, Dfs(row + 1, col1, col2));
                }
            }
        }
        return memo[key] = cherries + result;
    }
}

/*
same as longest increasing path 

dir1, dir2 robots directions

robot -> in each direction pick up the cherries and mark the cell as 0
after call complete revert it back to original

*/
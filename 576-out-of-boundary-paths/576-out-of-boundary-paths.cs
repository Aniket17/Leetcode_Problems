public class Solution {
    int MOD = (int)Math.Pow(10, 9) + 7;
    int[][] directions = new int[][]{
        new int[]{-1,0},
        new int[]{1,0},
        new int[]{0,1},
        new int[]{0,-1},
    };
    Dictionary<string, int> memo = new Dictionary<string, int>();
    public int FindPaths(int m, int n, int maxMove, int startRow, int startCol){
        if(maxMove < 0) return 0;
        if(startRow < 0 || startCol < 0 || startRow >= m|| startCol >= n){
            return 1;
        }
        var key = $"{startRow},{startCol},{maxMove}";
        if(memo.ContainsKey(key)) return memo[key];
        int ans = 0;
        foreach(var dir in directions){
            var row = startRow + dir[0];
            var col = startCol + dir[1];
            
            ans = (ans + FindPaths(m, n, maxMove - 1, row, col)%MOD)%MOD;
        }
        return memo[key] = ans;
    }
}
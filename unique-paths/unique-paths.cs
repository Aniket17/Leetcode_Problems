public class Solution {
    int[][] _dirs = new int[][]{
        new int[]{0,1},
        new int[]{1,0},
    };
    int[] memo;
    public int UniquePaths(int m, int n) {
        memo = new int[m*n];
        Array.Fill(memo, -1);
        return ExplorePaths(0, 0, m, n);
    }
    private int ExplorePaths(int i, int j, int m, int n){
        if(i == m - 1 && j == n - 1){
            return 1;
        }
        var key = i*n+j;
        if(memo[key] != -1) return memo[key];
        var max = 0;
        foreach(var dir in _dirs){
            var row = i+dir[0];
            var col = j+dir[1];
            if(IsValid(row, col, m, n)){
                max += ExplorePaths(row, col, m, n);
            }
        }
        return memo[key] = max;
    }
    bool IsValid(int row, int col, int m, int n){
        if(row < 0 || col < 0 || row >= m || col >= n){
            return false;
        }
        return true;
    }
}
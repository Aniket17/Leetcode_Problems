public class Solution {
    Dictionary<string, int> memo;
    public int CalculateMinimumHP(int[][] dungeon) {
        var m = dungeon.Length;
        var n = dungeon[0].Length;
        
        //bottom up dp
        
        var dp = new int[m][];
        for(int i = m - 1; i >= 0; i--){
            dp[i] = new int[n + 1];
            for(int j = n - 1; j >= 0; j--){
                //last cell
                if(i == m - 1 && j == n - 1){
                    dp[i][j] = Math.Min(0, dungeon[i][j]);
                }
                //last row - can only go right
                else if(i == m - 1){
                    dp[i][j] = Math.Min(0, dungeon[i][j] + dp[i][j + 1]);
                }
                //last col - can only go down
                else if(j == n - 1){
                    dp[i][j] = Math.Min(0, dungeon[i][j] + dp[i + 1][j]);
                }
                //somewhere in betn
                else{
                    dp[i][j] = Math.Min(0, dungeon[i][j] + Math.Max(dp[i + 1][j], dp[i][j + 1]));
                }
            }
        }
        return Math.Abs(dp[0][0]) + 1;
        
        // recursive works but gets TLE
        // var minHealth = Solve(dungeon, m - 1, n - 1, int.MaxValue, 0);
        // if(minHealth < 0){
        //     return (minHealth * -1) + 1;
        // }
        // return 1;
    }
    
    int Solve(int[][] matrix, int i, int j, int minSofar, int curr){
        if(i == 0 && j == 0){
            return Math.Min(minSofar, curr + matrix[i][j]);
        }
        
        if(i < 0 || j < 0){
            return int.MaxValue;
        }
        
        var newMinSofar = Math.Min(minSofar, curr + matrix[i][j]);
        var right = Solve(matrix, i, j - 1, newMinSofar, curr + matrix[i][j]);
        var down = Solve(matrix, i - 1, j, newMinSofar, curr + matrix[i][j]);
        
        if(right == int.MaxValue){
            return down;
        }
        
        if(down == int.MaxValue){
            return right;
        }
        return Math.Max(right, down);
    }
}

/*
shortest increasing path
maximizing minSoFar along the path

all power ups

choose max from right or down
add it to curr and minSofar = min(minSofar, curr)


*/
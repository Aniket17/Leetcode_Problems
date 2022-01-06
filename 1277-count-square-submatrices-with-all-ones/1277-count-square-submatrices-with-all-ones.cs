/*
[
  [0,1,1,1],
  [1,1,1,1],
  [0,1,1,1]
]

[
  [0,1,1,1],
  [1,1,2,2],
  [0,1,2,3]
]

*/

public class Solution {
    public int CountSquares(int[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        
//         var dp = new int[m][];
//         for(int row = 0; row < m; row++){
//             dp[row] = new int[n];
//             for(int col = 0; col < n; col++){
//                 dp[row][col] = matrix[row][col];
//             }
//         }
        
        for(int row = 1; row < m; row++){
            for(int col = 1; col < n; col++){
                if(matrix[row][col] == 0) continue;
                var sides = new List<int>(){
                    matrix[row - 1][col - 1],
                    matrix[row - 1][col],
                    matrix[row][col-1]
                };
                var min = sides.Min();
                matrix[row][col] += min;
                    
            }
        }
        return matrix.SelectMany(x=>x).Sum();
    }
}
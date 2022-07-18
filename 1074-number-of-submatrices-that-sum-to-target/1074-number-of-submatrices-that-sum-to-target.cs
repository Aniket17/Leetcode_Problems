public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var prefixSum = new int[m+1][];
        prefixSum[0] = new int[n + 1];
        for(int i = 1; i <= m; i++){
            prefixSum[i] = new int[n + 1];
            for(int j = 1; j <= n; j++){
                prefixSum[i][j] = matrix[i - 1][j - 1] 
                    + prefixSum[i][j-1] 
                    + prefixSum[i-1][j] 
                    - prefixSum[i-1][j-1];
            }
        }
        int count = 0, currentSum = 0;
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        for(int i = 1; i <= m; i++){
            for(int j = i; j <= m; j++){
                map = new Dictionary<int, int>();
                map[0] = 1;
                
                for(int k = 1; k < n + 1; k++){
                    currentSum = prefixSum[j][k] - prefixSum[i - 1][k];
                    
                    count += map.GetValueOrDefault(currentSum - target);
                    map[currentSum] = 1 + map.GetValueOrDefault(currentSum);
                }
            }
        }
        
        return count;
    }
}

/*
[
[1,-1]
[-1,1]
]
row
[
[1,0]
[-1,0]
]

col
[
[1,-1]
[0,0]
]
*/
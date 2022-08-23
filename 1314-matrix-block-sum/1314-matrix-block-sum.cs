public class Solution {
    public int[][] MatrixBlockSum(int[][] mat, int k) {
        var m = mat.Length;
        var n = mat[0].Length;
        for(int i = 0;i < m; i++){
            for(int j = 1; j < n; j++){
                mat[i][j] += mat[i][j-1];
            }
            //Console.WriteLine(string.Join(",", mat[i]));
        }
        //prefix sum created
        var res = new int[m][];
        for(int i = 0; i < m; i++){
            res[i] = new int[n];
            for(int j = 0; j < n; j++){
                var ans=0;
                for(int r = i-k; r <= i+k; r++){
                    var delta = 0;
                    if(r < 0 || r >= m) continue;
                    if(j-k > 0){
                        ans -= mat[r][j-k-1];
                    }
                    ans += mat[r][Math.Min(j+k, n-1)];
                }
                res[i][j] = ans;
            }
        }
        return res;
    }
}
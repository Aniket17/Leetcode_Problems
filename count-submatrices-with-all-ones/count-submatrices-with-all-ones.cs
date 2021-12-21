public class Solution {
    public int NumSubmat(int[][] matrix) {
     
        int m = matrix.Length;
        int n = matrix[0].Length;
        
        int[][] dp = new int[m][];
        //Fill 1st row
        for(int i=0;i<m;++i)
        {
            dp[i] = new int[n];
        }
        
        //Fill 1st col
        for(int i=0;i<m;i++)
        {
           int c = 0;
            for(int j = n - 1; j >= 0; j--){
                
                if(matrix[i][j] == 1){
                    c++;
                }else{
                    c = 0;
                }
                
                dp[i][j] = c;
            }
        }
        int ans = 0;
        //Now fill all other cells
        for(int i=0;i<m;i++)
        {
            for(int j=0;j<n;++j)
            {
                int x = int.MaxValue;
                
                for(int k = i; k < m; k++){
                    x = Math.Min(x, dp[k][j]);
                    ans += x;
                }
                
            }
        }
        return ans;
    }
}


/*



*/
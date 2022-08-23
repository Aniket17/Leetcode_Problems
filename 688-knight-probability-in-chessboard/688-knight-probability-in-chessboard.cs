public class Solution {
    public double KnightProbability(int N, int K, int sr, int sc) {
        double[][] dp = new double[N][];
        int[] dr = new int[]{2, 2, 1, 1, -1, -1, -2, -2};
        int[] dc = new int[]{1, -1, 2, -2, 2, -2, 1, -1};
        for(int i = 0; i < N; i++){
            dp[i] = new double[N];
        }
        dp[sr][sc] = 1;
        for (; K > 0; K--) {
            double[][] dp2 = new double[N][];
            for(int i = 0; i < N; i++){
                dp2[i] = new double[N];
            }
            for (int r = 0; r < N; r++) {
                for (int c = 0; c < N; c++) {
                    for (int k = 0; k < 8; k++) {
                        int cr = r + dr[k];
                        int cc = c + dc[k];
                        if (0 <= cr && cr < N && 0 <= cc && cc < N) {
                            dp2[cr][cc] += dp[r][c] / 8.0;
                        }
                    }
                }
            }
            dp = dp2;
        }
        double ans = 0.0;
        foreach(double[] row in dp) {
            foreach(double x in row) ans += x;
        }
        return ans;
    }
}

/*
2
0,0
2/8

*/
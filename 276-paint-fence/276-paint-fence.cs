public class Solution {
    public int NumWays(int n, int k) {
        var oneBack = k*k;
        var twoBack = k;
        if(n == 1) return twoBack;
        if(n == 2) return oneBack;
        var ways = 0;
        for(int i = 3; i <= n; i++){
            var temp = (k-1)*(oneBack+twoBack);
            twoBack = oneBack;
            oneBack = temp;
        }
        return oneBack;
    }
}

/*
n k w
7 2 2+ (6,2,1) = 12
6 2 2+ (5,2,2) = 10
5 2 2+ (4,1,0) = 8
4 1 1+ (3,2,1) = 7
3 2 2+ (2,2,2) = 6
2 2 4
*/
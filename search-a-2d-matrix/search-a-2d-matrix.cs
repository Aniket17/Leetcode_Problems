public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var m = matrix.Length;
        if(m == 0) return false;

        var n = matrix[0].Length;
        var left = 0;
        var right = m * n - 1;
        while(left <= right){
            var mid = (left + right) / 2;
            var el = matrix[mid / n][mid % n];
            if(el == target){
                return true;
            }else if(el > target){
                right = mid - 1;
            }else{
                left = mid + 1;
            }
        }
        return false;
    }
}


/*
3*4

0 1
2 3
4 5
6 7
8 9
10 11

9 => 2,1 => i * 3 + j = 9

*/
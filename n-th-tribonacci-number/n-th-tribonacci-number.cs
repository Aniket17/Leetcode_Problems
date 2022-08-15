public class Solution {
    int[] map = new int[38];
    public int Tribonacci(int n) {
        Array.Fill(map, -1);
        map[0] = 0;
        map[1] = 1;
        map[2] = 1;
        TribonacciUtil(n);
        return map[n];
    }
    int TribonacciUtil(int n){
        if(map[n] != -1) return map[n];
        return map[n] = TribonacciUtil(n - 1) + TribonacciUtil(n - 2) + TribonacciUtil(n - 3);
    }
}
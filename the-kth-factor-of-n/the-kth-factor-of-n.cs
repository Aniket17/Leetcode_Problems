public class Solution {
    public int KthFactor(int n, int k) {
        if(k == 1) return 1;
       var lastFactor = 1;
       for(int factor = 2; factor <= n; factor++){
           if(n % factor == 0){
               k--;
               lastFactor = factor;
           }
           if(k == 1){
               return lastFactor;
           }
       }
        return -1;
    }
}
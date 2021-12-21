public class Solution {
    public double TrimMean(int[] arr) {
        Array.Sort(arr);
        int len = arr.Length;
        
        var fivePerc = (int)(len * 0.05);
        double ans = 0;
        
        for(int i = fivePerc; i < len - fivePerc; i++){
            ans += arr[i];
        }
        ans = ans / (len - (fivePerc * 2));
        return ans;
    }
}
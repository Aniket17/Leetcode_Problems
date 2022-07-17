public class Solution {
    public double TrimMean(int[] arr) {
        Array.Sort(arr);
        var len = arr.Length;
        var fivePerc = (int)(len * 0.05);
        double totalSum = 0;
        for(int i = fivePerc; i < len - fivePerc; i++){
            totalSum += arr[i];
        }
        double ans = totalSum / (len - fivePerc - fivePerc);
        return ans;
    }
}
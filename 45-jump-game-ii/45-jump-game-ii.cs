public class Solution {
    public int Jump(int[] nums) {
        var n = nums.Length;
        int[] minJumps = new int[n];
        minJumps[n - 1] = 0;
        for(int i = n - 2; i >=0; i--){
            if(nums[i] == 0){
                  minJumps[i] = 0;   
                }else if(i + nums[i] >= n - 1){
                    minJumps[i] = 1;
                }else{
                    //find min from i too i+nums[i]
                    var min = GetMinValueBetween(i+1, i + nums[i], minJumps);
                    if(min != 0){
                        minJumps[i] = min + 1;
                    }
                }
        }
        return minJumps[0];
    }
    
    private int GetMinValueBetween(int i, int j, int[] minJumps){
        var min = int.MaxValue;
        for(; i <= j; i++){
            if(minJumps[i] > 0)
                min = Math.Min(minJumps[i], min);
        }
        return min == int.MaxValue ? 0: min;
    }
}
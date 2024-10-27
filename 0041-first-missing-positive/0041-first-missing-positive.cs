public class Solution {
    public int FirstMissingPositive(int[] nums) {
       //first pass mark all negative as int.max
       //second pass, if nums[i] < nums[i].Length num[i]th index will be marked as negative
       //first non negative index will be answer
       var n = nums.Length;
       for(int i = 0; i < n; i++){
        if(nums[i] <= 0) nums[i] = n+2;
       }

       Console.WriteLine("first iteration: "+string.Join(",", nums));

       for(int i = 0; i < n; i++){
        var num = nums[i];
        if(Math.Abs(num) - 1 < n && nums[Math.Abs(num) - 1] > 0)
            nums[Math.Abs(num) - 1] *= -1;
       }

       Console.WriteLine("second iteration: "+string.Join(",", nums));

       for(int i = 0; i < n; i++){
        if(nums[i] > 0){
            return i + 1;
        }
       }
       return n + 1;
    }

    /*
    [max,-3,4,-max,1] n = 5
    [max,7,8,9,11,12] n = 6
    [-max,-1,-2,0] n = 4
    */
}
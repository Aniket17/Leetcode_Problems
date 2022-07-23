public class Solution {
    int[] scores = new int[2];
    public bool PredictTheWinner(int[] nums) {
        var p = Solve(nums, 0, nums.Length - 1, 0);
        var sum = nums.Sum(x=>x);
        return p >= sum - p;
    }
    
    int Solve(int[] nums, int left, int right, int player){
        if(left > right) return 0;
       return player == 0 ? Math.Max(nums[left]+Solve(nums, left + 1, right, 1-player), nums[right]+Solve(nums, left, right - 1, 1-player)):
        Math.Min(Solve(nums, left + 1, right, 1-player), Solve(nums, left, right - 1, 1-player));
    }
    /*
    check both the posibilities
    if left > right return
    take 1 
    take last
    see who gets max
    */
}
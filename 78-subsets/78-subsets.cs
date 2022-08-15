public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var n = (int)Math.Pow(2, nums.Length) - 1;
        var ans = new List<IList<int>>();
        while(n >= 0){
            var res = new List<int>();
            var binary = Convert.ToString(n, 2).PadLeft(nums.Length, '0');
            
            for(int i = 0; i < binary.Length; i++){
                var ch = binary[i];
                if(ch == '1'){
                    res.Add(nums[i]);
                }
            }
            ans.Add(res);
            n--;
        }
        return ans;
    }
}

//generate binary sequence for 3 bits
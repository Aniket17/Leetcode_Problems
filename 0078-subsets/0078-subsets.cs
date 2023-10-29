public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
       var n = nums.Length;
       var result = new List<IList<int>>();

       for(var j = 0; j < Math.Pow(2, nums.Length); j++){
           var str = Convert.ToString(j, 2).PadLeft(nums.Length,'0');
           var res = new List<int>();
           for(var i = 0; i < nums.Length; i++){
               if(str[i] == '1'){
                   res.Add(nums[i]);
               }
           }
           result.Add(res);
       }

       return result;
    }
}
public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        
        var n = nums.Length;
        var max = Math.Pow(2,n);
        Array.Sort(nums);
        var set = new HashSet<string>();
        
        var result = new List<IList<int>>();
        for(int i = 0; i < max; i++){
            var mask = Convert.ToString(i, 2).PadLeft(n,'0');
            var list = new List<int>();
            for(int ch = 0; ch < n; ch++){
                if(mask[ch] == '1'){
                    list.Add(nums[ch]);
                }
            }
            //if dup, it will the last element
            var str = String.Join(",", list);
            if(set.Add(str)){
                result.Add(list);
            }
        }
        return result;
    }
}
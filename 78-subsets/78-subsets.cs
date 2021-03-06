public class Solution {
    /*
    [1,2,3]
    000 => []
    001  [3]
    010  [2]
    011  [2,3]
    100  [1]
    101  [1,3]
    110  [1,2]
    111  [1,2,3]    
    */
    List<IList<int>> subsets = new List<IList<int>>();
    
    //backtracking solution
    public IList<IList<int>> Subsets(int[] nums) {
        var n = nums.Length;
        Solve(0, nums, new List<int>());
        return subsets;
    }
    
    void Solve(int ind, int[] nums, List<int> ans){
        subsets.Add(ans.ToList());
        for(int i = ind; i < nums.Length; i++){
            // either add or dont add
            ans.Add(nums[i]);
            Solve(i + 1, nums, ans);
            ans.RemoveAt(ans.Count - 1);
        }
    }
    
    
    /*public IList<IList<int>> Subsets(int[] nums) {
        var n = nums.Length;
        for (int i = 0; i < (int)Math.Pow(2, n); ++i) {
            var bits = Convert.ToString(i,2).PadLeft(n, '0');
            
            var list = new List<int>();
            for(int ch = 0; ch < n; ch++){
                if(bits[ch] == '1'){
                    list.Add(nums[ch]);
                }
            }
            subsets.Add(list);
        }
        return subsets;
    }*/
    
}
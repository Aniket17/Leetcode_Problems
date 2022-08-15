public class Solution {
    int n, k;
    public IList<IList<int>> Subsets(int[] nums) {
        var ans = new List<IList<int>>();
        n = nums.Length;
        for(k = 0; k < n + 1; ++k){
            Generate(nums, 0, new List<int>(), ans);
        }
        return ans;
    }
    
    private void Generate(int[] nums, int pos, List<int> res, List<IList<int>> ans){
        if(res.Count == k){
            ans.Add(res.ToList());
            return;
        }
        for(int i = pos; i < n; ++i){
            res.Add(nums[i]);
            Generate(nums, i + 1, res, ans);
            res.RemoveAt(res.Count - 1);
        }
    }
}
public class Solution {
    int n, k;
    int[] nums;
    List<IList<int>> ans = new();
    public IList<IList<int>> Subsets(int[] nums) {
        this.nums = nums;
        n = nums.Length;
        for(k = 0; k < n + 1; ++k){
            Generate(0, new List<int>());
        }
        return ans;
    }
    
    private void Generate(int pos, List<int> res){
        if(res.Count == k){
            ans.Add(res.ToList());
            return;
        }
        for(int i = pos; i < n; ++i){
            res.Add(nums[i]);
            Generate(i + 1, res);
            res.RemoveAt(res.Count - 1);
        }
    }
}
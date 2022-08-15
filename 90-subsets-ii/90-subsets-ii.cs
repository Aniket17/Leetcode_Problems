public class Solution {
    int n, k;
    List<IList<int>> ans = new();
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        n = nums.Length;
        Array.Sort(nums);
        Generate(nums, 0, new List<int>());
        return ans;
        
    }

    void Generate(int[] nums, int pos, List<int> curr){
        ans.Add(curr.ToList());
        
        for(int i = pos; i < n; i++){
            if(i != pos && nums[i] == nums[i - 1]) continue;
            curr.Add(nums[i]);
            Generate(nums, i + 1, curr);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}
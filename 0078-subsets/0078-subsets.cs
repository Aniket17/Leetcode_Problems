public class Solution {
    List<IList<int>> result = new();
    public IList<IList<int>> Subsets(int[] nums) {
       Explore(0, nums, new List<int>());
       result.Add(new List<int>());
       return result;
    }
    void Explore(int i, int[] nums, IList<int> res){
        if(i >= nums.Length) return;
        //choose the ith index to be included
        res.Add(nums[i]);
        Explore(i+1, nums, res);
        result.Add(res.ToList());
        //choose the ith index not to be included
        res.RemoveAt(res.Count - 1);
        Explore(i+1, nums, res);
    }
}
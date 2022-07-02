/*
                        

*/

public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        List<IList<int>> result = new List<IList<int>>();
        var seen = new HashSet<int>();
        PermuteUtil(nums, new List<int>(), result, seen);
        return result;
    }
    
    private void PermuteUtil(int[] nums, List<int> ans, List<IList<int>> result, HashSet<int> seen){
        if(ans.Count == nums.Length){
            result.Add(ans.ToList());
            return;
        }
        
        foreach(int num in nums){
            if(seen.Contains(num)) continue;
            seen.Add(num);
            ans.Add(num);
            PermuteUtil(nums, ans, result, seen);
            seen.Remove(num);
            ans.RemoveAt(ans.Count - 1);
        }
    }
}
public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var ans = new List<IList<int>>();
        var counts = new Dictionary<int, int>();
        foreach(var num in nums){
            counts[num] = counts.GetValueOrDefault(num) + 1;
        }
        // if we sort the counts dict, we will get lexographically increasing permutations
        GetPermutations(new List<int>(), ans, counts, nums.Length);
        return ans;
    }
    
    void GetPermutations(List<int> result, List<IList<int>> ans, Dictionary<int, int> counts, int n) {
        if(result.Count == n){
            ans.Add(result.ToList());
        }
        
        foreach(var key in counts.Keys){
            if(counts[key] == 0){
                continue;
            }
            result.Add(key);
            counts[key]--;
            GetPermutations(result, ans, counts, n);
            counts[key]++;
            result.RemoveAt(result.Count - 1);
        }
        return;
    }
}
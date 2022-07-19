public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var map = new Dictionary<int, int>();
        foreach(var num in nums){
            map[num] = 1 + map.GetValueOrDefault(num);
        }
        var ans = new List<IList<int>>();
        PermuteUtil(map, new List<int>(), ans, nums.Length);
        return ans;
    }
    
    void PermuteUtil(Dictionary<int, int> map, List<int> result, List<IList<int>> ans, int n){
        if(result.Count == n){
            ans.Add(result.ToList());
            return;
        }
        foreach(int key in map.Keys){
            if(map[key] == 0){
                continue;
            }
            map[key]--;
            result.Add(key);
            PermuteUtil(map, result, ans, n);
            map[key]++;
            result.RemoveAt(result.Count - 1);
        }
    }
}
public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var map = CreateCountsMap(candidates);
        var subsets = new List<IList<int>>();
        GenerateSubsets(map, subsets, new List<int>(), target);
        return subsets;
    }
    
    void GenerateSubsets(Dictionary<int, int> map, List<IList<int>> result, List<int> ans, int target){
        if(target < 0) return;
        if(target == 0){
            result.Add(ans.ToList());
            return;
        }
        
        foreach(var key in map.Keys){            
            if(map[key] > 0 && key <= target){
                if(ans.Any() && ans.Last() > key) continue;
                ans.Add(key);
                map[key]--;
                GenerateSubsets(map, result, ans, target - key);
                ans.RemoveAt(ans.Count - 1);
                map[key]++;
            }
        }
    }
    
    Dictionary<int, int> CreateCountsMap(int[] candidates){
        var counts = new Dictionary<int, int>();
        Array.Sort(candidates);
        for(int i = 0; i < candidates.Length; i++){
            counts[candidates[i]] = counts.GetValueOrDefault(candidates[i]) + 1;
        }
        return counts;
    }
}
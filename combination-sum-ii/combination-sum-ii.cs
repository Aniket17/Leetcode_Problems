public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var ans = new List<IList<int>>();
        var counts = new Dictionary<int, int>();
        for(int i = 0; i < candidates.Length; i++){
            counts[candidates[i]] = counts.GetValueOrDefault(candidates[i]) + 1;
        }
        counts = counts.OrderBy(x=>x.Key).ToDictionary(x=>x.Key, x=>x.Value);
        Solve(counts, target, new List<int>(), ans);
        return ans;
    }
    
    private void Solve(Dictionary<int, int> counts, int target, List<int> result, List<IList<int>> ans)
    {
        if(target < 0) return;
        if(target == 0){
            ans.Add(result.ToList());
            return;
        }
        
        // for(int i = pos; i < candidates.Length; i++){
        //     if(result.Any() && result.Last() > candidates[i]) continue;
        //     if(i != pos && candidates[i] == candidates[i - 1]) continue;
        //     if(candidates[i] <= target){
        //         result.Add(candidates[i]);
        //         Solve(candidates, target - candidates[i], pos + 1, result, ans);
        //         result.RemoveAt(result.Count - 1);
        //     }
        // }
        
        foreach(var k in counts.Keys){
            if(k <= target && counts[k] > 0){
                if(result.Any() && result.Last() > k) continue;
                result.Add(k);
                counts[k]--;
                Solve(counts, target - k, result, ans);
                result.RemoveAt(result.Count - 1);
                counts[k]++;
            }
        }
    }
}

/*
[1,2,2,2,5]
5

*/
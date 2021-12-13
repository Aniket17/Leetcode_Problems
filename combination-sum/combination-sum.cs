public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var ans = new List<IList<int>>();
        var seen = new HashSet<string>();
        Array.Sort(candidates);
        Solve(candidates, target, new List<int>(), ans);
        return ans;
    }
    
    private void Solve(int[] candidates, int target, List<int> result, List<IList<int>> ans)
    {
        if(target < 0) return;
        if(target == 0){
            ans.Add(result.ToList());
            return;
        }
        
        for(int i = 0; i < candidates.Length; i++){
            if(result.Any() && result.Last() > candidates[i]) continue;
            if(candidates[i] <= target){
                result.Add(candidates[i]);
                Solve(candidates, target - candidates[i], result, ans);
                result.RemoveAt(result.Count - 1);
            }
        }
    }
}


/*
[2,3,6,7]
[7,6,3,2]

[7]
[2,3,2]

*/
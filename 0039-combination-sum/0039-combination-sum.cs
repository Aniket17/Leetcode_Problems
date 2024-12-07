public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var ans = new List<IList<int>>();
        Array.Sort(candidates);
        Explore(candidates, target, ans, new List<int>());
        return ans;
    }
    void Explore(int[] candidates, int target, List<IList<int>> ans, List<int> curr){
        if(target == 0){
            ans.Add(curr.ToList());
            return;
        }
        for(int i = 0; i < candidates.Length; i++){
            if(candidates[i] > target || curr.LastOrDefault() > candidates[i]) continue;
            curr.Add(candidates[i]);
            Explore(candidates, target - candidates[i], ans, curr);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}
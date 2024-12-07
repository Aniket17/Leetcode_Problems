public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var ans = new List<IList<int>>();
        var seen = new HashSet<string>();
        Explore(candidates, target, ans, new List<int>(), seen);
        return ans;
    }
    void Explore(int[] candidates, int target, List<IList<int>> ans, List<int> curr, HashSet<string> seen){
        if(target == 0){
            var sorted = curr.OrderBy(x=>x);
            var str = String.Join(",",sorted);
            if(seen.Contains(str)) return;
            seen.Add(str);
            ans.Add(curr.ToList());
            return;
        }
        for(int i = 0; i < candidates.Length; i++){
            if(candidates[i] > target) continue;
            curr.Add(candidates[i]);
            Explore(candidates, target - candidates[i], ans, curr, seen);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}
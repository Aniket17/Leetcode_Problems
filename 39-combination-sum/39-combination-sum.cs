public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var result = new List<IList<int>>();
        Array.Sort(candidates);
        Solve(candidates, target, new List<int>(), result);
        return result;
    }
    
    private void Solve(int[] candidates, int target, List<int> ans, List<IList<int>> result)
    {
        if(target == 0){
            result.Add(ans.ToList());
            return;
        }
        
        foreach(var c in candidates){
            if(ans.Any() && ans.Last() > c) continue;
            if(c <= target){
                //pick
                ans.Add(c);
                Solve(candidates, target - c, ans, result);
                ans.RemoveAt(ans.Count - 1);
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
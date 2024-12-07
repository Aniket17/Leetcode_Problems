public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var result = new List<IList<int>>();
        Backtrack(candidates, target, 0, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] candidates, int target, int start, List<int> current, List<IList<int>> result) {
        if (target == 0) {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = start; i < candidates.Length; i++) {
            if (candidates[i] <= target) {
                current.Add(candidates[i]);
                Backtrack(candidates, target - candidates[i], i, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
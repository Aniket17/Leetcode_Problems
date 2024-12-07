public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var candidates = new int[]{1,2,3,4,5,6,7,8,9};
        var subsets = new List<IList<int>>();
        GenerateSubsetsOfSizeK(candidates, 0, k, n, new List<int>(), subsets);
        return subsets;
    }

    void GenerateSubsetsOfSizeK(int[] candidates, int start, int k, int n, List<int> curr, List<IList<int>> subsets){
        if(curr.Count == k && n == 0){
            subsets.Add(curr.ToList());
            return;
        }

        for(int i = start; i < candidates.Length; i++){
            if(candidates[i] > n){ continue; }
            curr.Add(candidates[i]);
            GenerateSubsetsOfSizeK(candidates, i + 1, k, n - candidates[i], curr, subsets);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}
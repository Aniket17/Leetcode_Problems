public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var seen = new HashSet<string>();
        var ans = new List<IList<int>>();
        Array.Sort(nums);
        Solve(nums, 0, new List<int>(){}, ans);
        return ans;
    }
    
    void Solve(int[] nums, int pos, List<int> result, List<IList<int>> ans) {
        ans.Add(result.ToList());
        for(int i = pos; i < nums.Length; i++){
            if(i != pos && nums[i] == nums[i - 1]) continue;
            result.Add(nums[i]);
            Solve(nums, i+1, result, ans);
            result.RemoveAt(result.Count - 1);
        }
    }
}

/*
pos         i       result      ans     LN
0           0       [1]         []      0
1           1       [1,2]       [][1]   1
2           2       [1,2,3]     [][1][1,2]  2
3           3       [1,2,3]     [][1][1,2][1,2,3]
2           3       [1,2]       [][1][1,2][1,2,3]
1           2       [1,3]

*/
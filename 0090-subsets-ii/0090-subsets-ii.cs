public class Solution {
    List<IList<int>> subsets = new();
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var map = nums.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());
        GenerateSubsets(map, 0, new List<int>());
        return subsets;
    }

    void GenerateSubsets(Dictionary<int, int> map, int ind, List<int> ans){
        subsets.Add(ans.ToList());
        for(int i = ind; i < map.Count; i++){
            var key = map.Keys.ElementAt(i);
            if(map[key] == 0) continue;
            ans.Add(key);
            map[key]--;
            GenerateSubsets(map, i, ans);
            map[key]++;
            ans.RemoveAt(ans.Count-1);
        }
    }

    /*
    [1,2,2]
    map: [1:1, 2:2]

    i   subset  map
    0   [1]     [1:0, 2:2]
        [1,2]   [1:0, 2:1]
    1   [1,2,2] [1:0, 2:0]
    

    */
}
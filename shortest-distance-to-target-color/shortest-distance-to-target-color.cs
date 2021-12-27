public class Solution {
    public IList<int> ShortestDistanceColor(int[] colors, int[][] queries) {
        var map = new Dictionary<int, List<int>>();
        int i = 0;
        foreach(var c in colors){
            if(!map.ContainsKey(c)){
                map[c] = new List<int>();
            }
            map[c].Add(i);
            i++;
        }
        var ans = new List<int>();
        foreach(var query in queries){
            var target = query[0];
            var color = query[1];
            if(!map.ContainsKey(color)){
                ans.Add(-1);
                continue;
            }
            
            var arr = map[color].ToArray();
            var insert = Array.BinarySearch(arr, target);
            
            if (insert < 0) {
                insert = (insert + 1) * -1;
            }
            // Handling cases when:
            // - the target index is smaller than all elements in the indexList
            // - the target index is larger than all elements in the indexList
            // - the target index sits between the left and right boundaries
            if (insert == 0) {
                ans.Add(arr[insert] - target);
            } else if (insert == arr.Length) {
                ans.Add(target - arr[insert - 1]);
            } else {
                int leftNearest = target - arr[insert - 1];
                int rightNearest = arr[insert] - target;
                ans.Add(Math.Min(leftNearest, rightNearest));
            }
        }
        return ans;
    }
}
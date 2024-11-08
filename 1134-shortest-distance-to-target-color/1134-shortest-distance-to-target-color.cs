public class Solution {
    public IList<int> ShortestDistanceColor(int[] colors, int[][] queries) {
        var map = new Dictionary<int, List<int>>();
        map.Add(1, new());
        map.Add(2, new());
        map.Add(3, new());
        for(int i = 0;i<colors.Length; i++){
            map[colors[i]].Add(i);
        }
        var ans = new List<int>();
        foreach(var query in queries){
            var source = query[0];
            var options = map[query[1]];
            if(source >= colors.Length || !options.Any()){
                ans.Add(-1);
                continue;
            }
            
            var index = options.BinarySearch(source);
            
            if(index < 0){
                index = (index+1)*-1;
            }
            
            //index is 0
            //index is len
            //index is just large index than source
            if(index == 0){
                ans.Add(Math.Abs(options[0] - source));
            }
            else if(index == options.Count){
                ans.Add(Math.Abs(options.Last() - source));
            }else{
                var small = Math.Abs(options[index-1] - source);
                var large = Math.Abs(options[index] - source);
                ans.Add(Math.Min(small, large));
            }
        }
        return ans;
    }
}
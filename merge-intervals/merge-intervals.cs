public class Solution {
    public int[][] Merge(int[][] intervals) {
        intervals = intervals.OrderBy(x=>x[0]).ToArray();
        var merged = new List<int[]>();
        merged.Add(intervals.First());
        for(int i = 1; i < intervals.Length; i++){
            var curr = intervals[i];
            var last = merged.Last();
            if(last[1] >= curr[0]){
                //overlap
                last[1] = Math.Max(curr[1], last[1]);
            }else{
                merged.Add(curr);
            }
        }
        return merged.ToArray();
    }
}

/*
1 1
5 3

*/
public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var n = intervals.Length;
        if(n == 0) return new int[][]{newInterval};
        var result = new int[n+1][];
        var j = 0;
        int i = 0;
        var added = false;
        for(; i < n; i++){
            var curr = intervals[i];
            if(curr[0] < newInterval[0]){
                result[j++] = curr;
            }else{
                result[j++] = newInterval;
                added = true;
                break;
            }
        }
        while(i < n){
            result[j++] = intervals[i++];
        }
        if(!added){
            result[j++] = newInterval;
        }
        return Merge(result);
    }
    
    public int[][] Merge(int[][] intervals) {
        //Console.WriteLine(string.Join(",", intervals.Select(x=>$"[{x[0]},{x[1]}]")));
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
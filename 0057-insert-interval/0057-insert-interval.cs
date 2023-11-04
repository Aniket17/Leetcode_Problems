public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        //find the pos => curr[0]<newInterval[0]
        var pos = 0;
        var sorted = new int[intervals.Length+1][];
        while(pos < intervals.Length && intervals[pos][0] < newInterval[0]){
            sorted[pos] = intervals[pos];
            pos++;
        }
        sorted[pos++] = newInterval;
        while(pos <= intervals.Length){
            sorted[pos] = intervals[pos-1];
            pos++;
        }
        return Merge(sorted);
    }

    public int[][] Merge(int[][] sorted) {
        //no overlap
        //newIntervals.end < curr.start
        //newInternval.start > curr.end
        var ans = new List<int[]>(){sorted[0]};
        foreach(var interval in sorted.Skip(1)){
            var last = ans.Last();
            if(interval[0] > last[1]){
                ans.Add(interval);
                continue;
            }
            ans.RemoveAt(ans.Count - 1);
            ans.Add(new int[]{Math.Min(last[0], interval[0]), Math.Max(last[1], interval[1])});
        }

        return ans.ToArray();
    }
}
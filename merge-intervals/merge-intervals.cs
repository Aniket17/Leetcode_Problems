public class Solution {
    public int[][] Merge(int[][] intervals) {
        if(intervals.Length < 2) return intervals;
        var sortedIntervals = intervals.OrderBy(x=> x[0]).ToArray();
        
        var mergedIntervals = new List<int[]>();
        mergedIntervals.Add(sortedIntervals[0]);
        
        for(int i = 1; i < sortedIntervals.Length; i++){
            var lastMerged = mergedIntervals.Last();
            var currentCount = mergedIntervals.Count;
            if(lastMerged[1] >= sortedIntervals[i][0]){
                // current end is greater than next start
                // next is starting before current ends, overlap
                mergedIntervals[currentCount - 1][1] = Math.Max(sortedIntervals[i][1],lastMerged[1]);
                
            }else{
                mergedIntervals.Add(sortedIntervals[i]);
            }
        }
        return mergedIntervals.ToArray();
    }
}

/*
[[1,3],[2,6],[8,10],[15,18]]

[[1,6], [8,10], [15,18]]

*/
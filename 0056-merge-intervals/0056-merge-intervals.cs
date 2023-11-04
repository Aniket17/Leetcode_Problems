public class Solution {
    public int[][] Merge(int[][] intervals) {
        //no overlap
        //newIntervals.end < curr.start
        //newInternval.start > curr.end
        var sorted = intervals.OrderBy(x=>x[0]).ToArray();
        var ans = new List<int[]>(){sorted[0]};
        foreach(var interval in sorted.Skip(1)){
            var last = ans.Last();
            if(interval[1] < last[0] || interval[0] > last[1]){
                ans.Add(interval);
                continue;
            }
            ans.RemoveAt(ans.Count - 1);
            ans.Add(new int[]{Math.Min(last[0], interval[0]), Math.Max(last[1], interval[1])});
        }

        return ans.ToArray();
    }

    /*
    [[1,3],[2,6],[8,10],[15,18]]
    iteration last interval ans
    1         [1,3] [2,6]   [1,6]
    2         [1,6] [8,10]  [1,6] [8,10]
    3         []
    */
    
}
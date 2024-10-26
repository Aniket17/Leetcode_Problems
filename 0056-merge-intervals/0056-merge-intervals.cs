public class Solution {
    public int[][] Merge(int[][] intervals) {
        //overlapping intervals are when 
        // start1 lies betn start2 and end2
        // or end1 lies betn start2 and end2
        // this covers partial overlap both right and left partial and also full overlap where entire interval lies in betn
        // do we need to consider these differely while mergine?
        // everytime we need to pick min of start and max of end and thats the merged interval
        // for this logic to work we need to sort the original intervals by start
        if (intervals.Length == 0) return new int[0][];  // Handle empty input
        var sorted = intervals.OrderBy(x=>x[0]).ToList(); //o(nlogn + n)
        var merged = new List<int[]>(){sorted[0]};

        for (int i = 1; i < sorted.Count; i++) {
            var last = merged.Last();  // Last merged interval
            var current = sorted[i];   // Current interval
            
            // Check for overlap
            if (current[0] <= last[1]) {
                // Overlap detected, merge the intervals
                last[1] = Math.Max(last[1], current[1]);
            } else {
                // No overlap, add the current interval to merged list
                merged.Add(current);
            }
        }

        return merged.ToArray();
    }
}
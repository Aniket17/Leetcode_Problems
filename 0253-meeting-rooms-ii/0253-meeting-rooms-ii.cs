using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        if (intervals == null || intervals.Length == 0)
            return 0;

        // Sort the intervals based on the start time
        var sortedIntervals = intervals.OrderBy(x => x[0]).ToArray();

        // Initialize a min heap (priority queue) ordered by end time
        var minHeap = new PriorityQueue<int[], int>();
        minHeap.Enqueue(sortedIntervals[0], sortedIntervals[0][1]);

        // Iterate over the remaining intervals
        for(int i = 1; i < sortedIntervals.Length; i++){
            var current = sortedIntervals[i];
            var earliestEnd = minHeap.Peek()[1];

            if (earliestEnd <= current[0]){
                // The room is free, reuse it by removing the earliest ending meeting
                minHeap.Dequeue();
            }

            // Allocate the current meeting to a room (new or reused)
            minHeap.Enqueue(current, current[1]);
        }

        // The size of the heap is the number of rooms required
        return minHeap.Count;
    }
}

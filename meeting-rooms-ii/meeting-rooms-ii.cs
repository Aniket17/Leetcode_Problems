public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        var n = intervals.Length;
        if(n<2) return n;
        intervals = intervals.OrderBy(x=>x[0]).ToArray();
        var heap = new PriorityQueue<int, int>();
        heap.Enqueue(intervals[0][1], intervals[0][1]);
        for(int i = 1; i < n; i++){
            if(intervals[i][0] >= heap.Peek()){
                heap.Dequeue();
            }
            heap.Enqueue(intervals[i][1], intervals[i][1]);
        }
        return heap.Count;
    }
}

/*
[[2,4],[7,10]]
*/
public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        var heap = new PriorityQueue<int[], int>();
        intervals = intervals.OrderBy(x=>x[0]).ToArray();
        heap.Enqueue(intervals[0], intervals[0][1]);

        for(int i = 1; i < intervals.Length; i++){
            int[] curr = intervals[i];
            int[] top = heap.Peek();
            if(top[1] <= curr[0]){
                heap.Dequeue();
            }
            heap.Enqueue(curr, curr[1]);
        }
        return heap.Count;
    }
}

//store meetings in min heap sorted by duration
//add 1st to heap increase the rooms
//for every other, check if heap.peek is overlapping, if yes, add next one and increase the rooms
//if it does not overlap, then dequeue from heap and add new one, no increase in rooms
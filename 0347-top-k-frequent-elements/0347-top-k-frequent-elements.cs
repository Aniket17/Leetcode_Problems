public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var counts = new Dictionary<int, int>();
        foreach(var num in nums){
            counts[num] = 1 + counts.GetValueOrDefault(num);
        }
        var heap = new PriorityQueue<int, int>();
        foreach(var key in counts.Keys){
            heap.Enqueue(key, counts[key]);
            while(heap.Count > k) heap.Dequeue();
        }
        var result = new int[k];
        while(k-- != 0){
            result[k] = heap.Dequeue();
        }
        return result;
    }
}
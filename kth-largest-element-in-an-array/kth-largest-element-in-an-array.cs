public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> queue = new();
        foreach(var num in nums){
            queue.Enqueue(num, num);
            if(queue.Count > k){
                queue.Dequeue();
            }
        }
        return queue.Peek();
    }
}
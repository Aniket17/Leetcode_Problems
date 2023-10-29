public class Solution {
    public class MaxIntComparer:IComparer<int>{
        public int Compare(int x, int y){
            return y.CompareTo(x);
        }
    }
    public int LastStoneWeight(int[] stones) {
        var heap = new PriorityQueue<int, int>(new MaxIntComparer());
        foreach(var stone in stones){
            heap.Enqueue(stone, stone);
        }

        while(heap.Count > 1){
            var weight = Math.Abs(heap.Dequeue() - heap.Dequeue());
            heap.Enqueue(weight, weight);
        }

        return heap.Count == 0 ? 0 : heap.Dequeue();
    }
}
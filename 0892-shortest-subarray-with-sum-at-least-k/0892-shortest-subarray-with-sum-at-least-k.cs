public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        int n = nums.Length;
        var pq = new PriorityQueue<(long, int), long>();
        long sum = 0;
        var shortestLength = int.MaxValue;
        for(int i = 0; i < nums.Length; i++){
            sum += nums[i];
            if(sum >= k){
                shortestLength = Math.Min(shortestLength, i + 1);
                //shrink
            }
            while(pq.Count > 0){
                var (topSum, topIndex) = pq.Peek();
                if(sum - topSum >= k){
                    shortestLength = Math.Min(shortestLength, i - topIndex);
                    pq.Dequeue();
                }else{
                    break;
                }
            }
            pq.Enqueue((sum, i), sum);
        }
        return shortestLength == int.MaxValue ? -1 : shortestLength;
    }
}

/*
nums = [2, -1, 1, 3] and k = 4.
i   sum pq
0   2   (2,0)
1   1   (1,1),(2,0)
2   2   (1,1),(2,0),(2,2) //shortestLength = 4
3   5   (2,0),(2,2) //shortestLength = 2

*/
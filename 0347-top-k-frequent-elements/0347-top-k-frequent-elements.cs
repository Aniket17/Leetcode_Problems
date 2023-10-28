public class Solution {
    public class IntMaxComparer:IComparer<int>{
        public int Compare(int x, int y){
            return y.CompareTo(x);
        }
    }
    public int[] TopKFrequent(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        foreach(var n in nums){
            if(map.ContainsKey(n)){
                map[n]++;
            }else{
                map[n] = 1;
            }
        }

        var heap = new PriorityQueue<int, int>(new IntMaxComparer());
        foreach(var kv in map){
            heap.Enqueue(kv.Key, kv.Value);
        }
        var ans = new List<int>();
        while(k != 0){
            ans.Add(heap.Dequeue());
            k--;
        }

        return ans.ToArray();
    }
}
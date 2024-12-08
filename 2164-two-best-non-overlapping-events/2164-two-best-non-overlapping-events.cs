public class Solution {
    public int MaxTwoEvents(int[][] events) {
        events = events.OrderBy(x=>x[0]).ToArray();
        var memo = new Dictionary<(int, int), int>();
        return Find(events, 0, 0, memo);
    }

    int Find(int[][] events, int index, int count, Dictionary<(int, int), int> memo){
        if(index >= events.Length || count == 2){
            return 0;
        }
        if(memo.ContainsKey((index, count))) return memo[(index, count)];
        var end = events[index][1];
        int low = index + 1, high = events.Length - 1;
        var targetIndex = -1;
        while(low <= high){
            var mid = low + (high - low)/2;
            if(events[mid][0] > end){
                targetIndex = mid;
                high = mid - 1;
            }else{
                low = mid + 1;
            }
        }
        var include = events[index][2] + (targetIndex == -1 ? 0 : Find(events, targetIndex, count + 1, memo));
        var exclude = Find(events, index + 1, count, memo);
        return memo[(index, count)] = Math.Max(include, exclude);
    }
}
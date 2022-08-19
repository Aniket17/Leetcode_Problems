public class Solution {
    public int MinSetSize(int[] arr) {
        var map = new Dictionary<int, int>();
        foreach(var n in arr){
            map[n] = 1 + map.GetValueOrDefault(n);
        }
        var sorted = map.OrderByDescending(x=>x.Value).Select(x=>x.Value).ToList();
        var limit = arr.Length/2;
        var count = 0;
        var sum = 0;
        foreach(var num in sorted){
            sum += num;
            count++;
            if(sum >= limit) break;
        }
        return count;
    }
}
// create counts map, sort it by count desc
// get min set by removing counts > size/2
// return size of minset
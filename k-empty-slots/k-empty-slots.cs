public class Solution {
    public int KEmptySlots(int[] bulbs, int k) {
        var n = bulbs.Length;
        int[] position = new int[n + 1]; // 1 0 1 0 0 1 etc
        for(int i = 0; i < n; i++){
            position[bulbs[i]] = i + 1;
        }
        
        int res = int.MaxValue;
        
        int start = 1; 
        int end = k + 2;
        
        for(int i = 1; end <= n; i++){
            if(position[i] > position[start] && position[i] > position[end]){
                continue;
            }
            
            if(i == end){
                res = Math.Min(res, Math.Max(position[start], position[end]));
            }
            
            start = i;
            end = i + k + 1;
        }
        
        return res == int.MaxValue ? -1 : res;
        
    }
}
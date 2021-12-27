public class Solution {
    public int SlidingPuzzle(int[][] board) {
        var queue = new Queue<string>();
        
        string target = "123450";
        
        var src = string.Join("",board.SelectMany(x=>x));
        var map = new Dictionary<int, List<int>>();
        var swaps = new List<List<int>>(){
            new List<int>(){1,3},
            new List<int>(){0,2,4},
            new List<int>(){1,5},
            new List<int>(){0,4},
            new List<int>(){1,3,5},
            new List<int>(){2,4},
        };

        queue.Enqueue(src);
        
        int level = 0;
        
        var seen = new HashSet<string>();
        
        while(queue.Count > 0){
            var size = queue.Count;
            
            while(size-- > 0){
                var rem = queue.Dequeue();
                if(rem.Equals(target)){
                    return level;
                }
                
                int idx = -1;
                for(int i = 0; i < rem.Length; i++){
                    if(rem[i] == '0'){
                        idx = i;
                        break;
                    }
                }
                
                List<int> swap = swaps[idx];
                
                for(int i = 0; i < swap.Count; i++){
                    var strToBeAdded = SwapChar(rem, idx, swap[i]);
                    if(seen.Contains(strToBeAdded)){
                        continue;
                    }
                    queue.Enqueue(strToBeAdded);
                    seen.Add(strToBeAdded);
                }
               
            }
            level++;
        }
        return -1;
    }
    
    private string SwapChar(string s, int i, int j){
        var sb = new StringBuilder();
        for(int pos = 0; pos < s.Length; pos++){
            if(pos == i){
                sb.Append(s[j]);
                continue;
            }
            if(pos == j){
                sb.Append(s[i]);
                continue;
            }
            sb.Append(s[pos]);
        }
        return sb.ToString();
    }
    
}
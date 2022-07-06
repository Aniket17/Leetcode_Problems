public class Solution {
    TrieNode root = new TrieNode();
    public int FindMaximumXOR(int[] nums) {
        foreach(var n in nums){
            var node = root;
            for(int i = 31; i >= 0; i--){
                var bit = (n >> i) & 1;
                if(!node.Contains(bit)){
                    node.Insert(bit);
                }
                node = node.Get(bit);
            }
        }
        
        var max = 0;
        foreach(var n in nums){
            max = Math.Max(max, GetMaxXORWith(n));
        }
        return max;
    }
    
    public int GetMaxXORWith(int n){
        var node = root;
        int max = 0;
        for(int i = 31; i >= 0; i--){
            var bit = (n >> i) & 1;
            var neg = 1 - bit;
            
            if(node.Contains(neg)){
                max = max | 1 << i;
                node = node.Get(neg);
            }else{
                node = node.Get(bit);   
            }
        }
        return max;
    }
    
    class TrieNode{
        public TrieNode[] children = new TrieNode[2];
        // 0 and 1
        
        public bool Contains(int bit) => children[bit] != null;
        public TrieNode Get(int bit) => children[bit];
        public void Insert(int bit) => children[bit] = new TrieNode();
    }
}
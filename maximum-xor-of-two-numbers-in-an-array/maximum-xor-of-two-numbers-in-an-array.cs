public class Solution {
    
    class Node{
        Node[] children;
        public Node(){
            children = new Node[2];
        }
        
        public Node Get(int bit){
            return children[bit];
        }
        public bool Contains(int bit){
            return children[bit] != null;
        }
        public void Insert(int bit, Node node){
             children[bit] = node;
        }
    }
    
    class Trie{
        public Node root;
        
        public Trie(){
            root = new Node();
        }
        
        public void Insert(int num){
            var node = root;
            for(int i = 31; i >= 0; i--){
                var bit = (num >> i) & 1;
                if(!node.Contains(bit)){
                    node.Insert(bit, new Node());
                }
                node = node.Get(bit);
            }
        }
        
        public int GetMax(int num){
            var max = 0;
            var node = root;
            for(int i = 31; i >= 0; i--){
                var bit = (num >> i) & 1;
                var neg = 1 - bit;
                if(node.Contains(neg)){
                    max = max | (1 << i);
                    node = node.Get(neg);
                }else{
                    node = node.Get(bit);
                }
            }
            return max;
        }
    }
    
    public int FindMaximumXOR(int[] nums) {
        var trie = new Trie();
        foreach(var num in nums){
            trie.Insert(num);
        }
        var max = 0;
        foreach(var num in nums){
            max = Math.Max(max, trie.GetMax(num));
        }
        return max;
    }
}
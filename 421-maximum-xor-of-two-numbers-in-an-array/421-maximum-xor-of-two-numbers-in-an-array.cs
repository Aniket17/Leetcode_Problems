public class Solution {
    TrieNode root = new TrieNode(0);
    public int FindMaximumXOR(int[] nums) {
        foreach(var n in nums){
            AddToTrie(n);
        }
        var max = 0;
        foreach(var n in nums){
            max = Math.Max(max, GetMaximum(n));
        }
        return max;
    }
    int GetMaximum(int n){
        var tmp = root;
        var maxNum = 0;
        for(int i = 31; i >= 0; i--){
            var bit = (n>>i)&1;
            if(tmp.children[1-bit] != null){
                maxNum = maxNum | 1<<i;
                tmp = tmp.children[1-bit];
            }else{
                tmp = tmp.children[bit];
            }
        }
        return maxNum;
    }
    void AddToTrie(int n){
        var tmp = root;
        for(int i = 31; i >= 0; i--){
            var bit = (n>>i)&1;
            var node = new TrieNode(bit);
            if(tmp.children[bit] == null){
                tmp.children[bit] = node;
            }else{
                node = tmp.children[bit];
            }
            tmp = node;
        }
    }
    public class TrieNode{
        public int val;
        public TrieNode[] children;
        public TrieNode(int v){
            val = v;
            children = new TrieNode[2];
        }
    }
}

/*
xor -> 
0^0=0 
1^1=0
0^1=1
get ith bit of n= n>>i&1
set ith bit of n= 1<<i|n
*/
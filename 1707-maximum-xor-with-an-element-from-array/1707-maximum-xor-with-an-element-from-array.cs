public class Solution {
    TrieNode root = new TrieNode(0);
    public int[] MaximizeXor(int[] nums, int[][] queries) {
        Array.Sort(nums);
        var sortedQueries = new int[queries.Length][];
        for(var i = 0; i < queries.Length; i++){
            sortedQueries[i] = new int[]{i, queries[i][0], queries[i][1]};
        }
        
        sortedQueries = sortedQueries.OrderBy(x=>x[2]).ToArray();
        Console.WriteLine(string.Join(",", sortedQueries.Select(x=>$"{x[1]},{x[2]} ")));
        var index = 0;
        var ans = new int[sortedQueries.Length];
        foreach(var query in sortedQueries){
            while(index < nums.Length && nums[index] <= query[2]){
                AddToTrie(nums[index]);
                index++;
            }
            ans[query[0]] = index == 0 ? -1: GetMaximum(query[1]);
        }
        return ans;
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
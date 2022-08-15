public class Solution {
    TrieNode root = new();
    HashSet<string> foundWords = new();
    int[][] dirs = new int[][]{new int[]{1,0},
                              new int[]{0,1},
                              new int[]{-1,0},
                              new int[]{0,-1}};
    
    public IList<string> FindWords(char[][] board, string[] words) {
        var m = board.Length;
        var n = board[0].Length;
        words.ToList().ForEach(AddToTrie);
        for(int row = 0; row < m; row++){
            for(int col = 0; col < n; col++){
                if(root.children.ContainsKey(board[row][col])){
                    HasWordPath(board, row, col, new HashSet<int>(){row*n+col}, root);
                }
            }
        }
        return foundWords.ToList();
    }
    
    private void HasWordPath(char[][] board, int i, int j, HashSet<int> seen, TrieNode parent){
        var m = board.Length;
        var n = board[0].Length;
        var node = parent.children[board[i][j]];
        if(node.word != ""){
            foundWords.Add(node.word);
            node.word = "";
        }
        
        foreach(var dir in dirs){
            var row = i + dir[0];
            var col = j + dir[1];
            if(IsValid(row, col, m, n) 
               && !seen.Contains(row*n+col)
              && node.children.ContainsKey(board[row][col]))
            {
                seen.Add(row*n+col);
                HasWordPath(board, row, col, seen, node);
                seen.Remove(row*n+col);
            }
            
            if(node.children.Count == 0){
                parent.children.Remove(board[i][j]);
            }
        }
    }
    
    private bool IsValid(int row, int col, int m, int n){
        if(row < 0 || col < 0 || row >= m || col >= n){
            return false;
        }
        return true;
    }
    
    public class TrieNode{
        public Dictionary<char, TrieNode> children = new();
        public string word = "";
    }
    
    private void AddToTrie(string word){
        var node = root;
        foreach(var ch in word){
            if(!node.children.ContainsKey(ch)){
                node.children[ch] = new();
            }
            node = node.children[ch];
        }
        node.word = word;
    }
    
    private TrieNode GetWordNode(string word){
        var node = root;
        foreach(var ch in word){
            if(!node.children.ContainsKey(ch)){
                return null;
            }
            node = node.children[ch];
        }
        return node;
    }
}
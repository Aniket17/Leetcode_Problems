public class Trie {
    TrieNode root;
    public Trie() {
        root = new TrieNode('\0');
    }
    
    public void Insert(string word) {
        var node = root;
        for(int i = 0; i < word.Length; i++){
            char ch = word[i];
            if(node.HasChild(ch)){
                node = node.GetNode(ch);
                if(i == word.Length - 1){
                    node.isWord = true;
                }
            }else{
                var newNode = new TrieNode(ch, i == word.Length - 1);
                node.children.Add(ch, newNode);
                node = newNode;
            }
        }
    }
    
    public bool Search(string word) {
        var node = root;
        foreach(var ch in word){
            if(node.HasChild(ch)){
                node = node.GetNode(ch);
            }else{
                return false;
            }
        }
        return node.isWord;
    }
    
    public bool StartsWith(string prefix) {
        var node = root;
        foreach(var ch in prefix){
            if(node.HasChild(ch)){
                node = node.GetNode(ch);
            }else{
                return false;
            }
        }
        return true;
    }
    
    public class TrieNode{
        public char val;
        public bool isWord;
        public Dictionary<char, TrieNode> children;
        public TrieNode(char ch, bool isWord = false){
            children = new Dictionary<char, TrieNode>();
            this.isWord = isWord;
            val = ch;
        }
        
        public bool HasChild(char ch){
            return children.ContainsKey(ch);
        }
        
        public TrieNode GetNode(char ch){
            if(HasChild(ch)) return children[ch];
            return null;
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
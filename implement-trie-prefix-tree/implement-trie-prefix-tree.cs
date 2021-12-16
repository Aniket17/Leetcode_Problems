public class Trie {

    class TrieNode{
        char ch;
        public Dictionary<char, TrieNode> children;
        public bool isWord;
        public TrieNode(char ch){
            this.ch = ch;
            children = new Dictionary<char, TrieNode>();
        }
    }
    
    TrieNode root;
    
    public Trie() {
        root = new TrieNode('\0');
    }
    
    public void Insert(string word) {
        var temp = root;
        foreach(var c in word){
            var newNode = new TrieNode(c);
            if(temp.children.ContainsKey(c)){
                temp = temp.children[c];
            }else{
                temp.children.Add(c, newNode);
                temp = newNode;
            }
        }
        temp.isWord = true;
    }
    
    public bool Search(string word) {
        var temp = root;
        foreach(var c in word){
            if(temp.children.ContainsKey(c)){
                temp = temp.children[c];
            }else{
                return false;
            }
        }
        return temp.isWord;
    }
    
    public bool StartsWith(string prefix) {
        var temp = root;
        foreach(var c in prefix){
            if(temp.children.ContainsKey(c)){
                temp = temp.children[c];
            }else{
                return false;
            }
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
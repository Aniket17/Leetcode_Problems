public class Trie {
    TrieNode root;
    public Trie() {
        root = new TrieNode('\0');
    }
    
    public void Insert(string word) {
        var node = root;
        foreach(var ch in word){
            var curr = node.Find(ch);
            if(curr == null){
                node = node.Append(ch);
            }else{
                node = curr;
            }
        }
        node.MarkComplete();
    }
    
    public bool Search(string word) {
        var node = root;
        foreach(var ch in word){
            var curr = node.Find(ch);
            if(curr == null) return false;
            node = curr;
        }
        return node.IsComplete();
    }
    
    public bool StartsWith(string prefix) {
        var node = root;
        foreach(var ch in prefix){
            var curr = node.Find(ch);
            if(curr == null) return false;
            node = curr;
        }
        return true;
    }
}

public class TrieNode{
    private char ch;
    private TrieNode[] children;
    private bool isWord;
    public TrieNode(char ch){
        this.ch = ch;
        children = new TrieNode[128];
        isWord = isWord;
    }

    public TrieNode Find(char ch){
        return children[ch];
    }
    
    public TrieNode Append(char ch){
        children[ch] = new TrieNode(ch);
        return children[ch];
    }

    public void MarkComplete(){
        this.isWord = true;
    }

    public bool IsComplete() => isWord;
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
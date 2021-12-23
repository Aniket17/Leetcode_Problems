public class StreamChecker {

    public class Node{
        public char ch;
        public bool word;
        public Dictionary<char, Node> child;
        public Node(char c){
            ch = c;
            child = new Dictionary<char, Node>();
        }
    }
    
    public class Trie{
        public Node root = new Node('0');
        
        public void Insert(string[] words){
            foreach(var w in words){
                var tmp = root;
                for(int i = w.Length - 1; i >= 0; i--){
                    var ch = w[i];
                    if(tmp.child.ContainsKey(ch)){
                        tmp = tmp.child[ch];
                    }else{
                        tmp.child.Add(ch, new Node(ch));
                        tmp = tmp.child[ch];
                    }
                }
                tmp.word = true;
            }
        }
        
        public bool Query(string str){
            var tmp = root;
            foreach(var ch in str){
                if(tmp.word == true) return true;
                if(!tmp.child.ContainsKey(ch)){
                    return false;
                }
                tmp = tmp.child[ch];
            }
            return tmp.word;
        }
    }
    
    Trie trie;
    string curr;
    public StreamChecker(string[] words) {
        trie = new Trie();
        trie.Insert(words);
        curr = "";
    }
    
    public bool Query(char letter) {
        curr = $"{letter}{curr}";
        return trie.Query(curr);
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);
 */
public class Solution {
    public int LadderLength(string src, string dst, IList<string> wordList) {
        var set = wordList.ToHashSet();
        if(!set.Contains(dst)) return 0;
        var count = 0;        
        var queue = new Queue<string>();
        queue.Enqueue(src);
        while(queue.Count != 0){
            var ct = queue.Count;
            count++;
            while(ct-- > 0){
                var word = queue.Dequeue();
                for(int i = 0; i < word.Length; i++){
                    var sb = new StringBuilder(word);
                    for(char ch = 'a'; ch <= 'z'; ch++){
                        if(ch == word[i]) continue;
                        sb[i] = ch;
                        var newWord = sb.ToString();
                        if(newWord == dst) return count + 1;
                        if(set.Contains(newWord)){
                            queue.Enqueue(newWord);
                            set.Remove(newWord);
                        }
                    }
                }
            }
        }
        return 0;
    }
}
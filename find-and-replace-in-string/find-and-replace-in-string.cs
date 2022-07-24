public class Solution {
    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets) {
        Dictionary<int, int> replaced = new();
        int i = 0;
        for(i = 0; i < indices.Length; i++){
            var src = sources[i];
            var trg = targets[i];
            var id = indices[i];
            if(id >=0 && id < s.Length && s.Substring(id, Math.Min(src.Length, s.Length-id)) == src){
                replaced[indices[i]] = i;
            }
        }
        var sb = new StringBuilder();
        i = 0;
       // Console.WriteLine(string.Join(",",replaced.Select(x=>$"{x.Key}:{x.Value}\n")));
        while(i < s.Length){
            if(replaced.ContainsKey(i)){
                var targetIndex = replaced[i];
                sb.Append(targets[targetIndex]);
                i += sources[targetIndex].Length;
            }else{
                sb.Append(s[i]);
                i++;
            }
        }
        return sb.ToString();
    }
    /*
    replaced = {indexInS: indexOfSrc}
    s = "abcd", indices = [0, 2], sources = ["a", "cd"], targets = ["eee", "ffff"]
    0 {0: 0}
    1 {2: 1}
    eeebffff
    */
}
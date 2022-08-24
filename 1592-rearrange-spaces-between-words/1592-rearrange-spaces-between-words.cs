public class Solution {
    public string ReorderSpaces(string text) {
        var totalSpaces = text.Where(x=>x==' ').Count();
        var words = text
            .Split(" ")
            .Select(x=>x.Trim())
            .Where(x=>!string.IsNullOrEmpty(x))
            .ToList();
        var sb = new StringBuilder(words[0]);
        
        if(words.Count == 1){
            AppendSpaces(totalSpaces, sb);
            return sb.ToString();
        }
        var spaces = totalSpaces/(words.Count-1);
        var extra = totalSpaces%(words.Count-1);
        for(int i = 1; i < words.Count; i++){
            AppendSpaces(spaces, sb);
            sb.Append(words[i]);
        }
        AppendSpaces(extra, sb);
        return sb.ToString();
    }
    
    void AppendSpaces(int k, StringBuilder sb){
        for(int s = 1; s <= k; s++){
            sb.Append(" ");
        }
    }
}
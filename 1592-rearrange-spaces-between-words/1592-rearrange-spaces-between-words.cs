public class Solution {
    public string ReorderSpaces(string text) {
        var spaces = 0;
        int i = 0;
        var words = new List<string>();
        var sb = new StringBuilder();
        while(i < text.Length){
            var ch = text[i++];
            if(ch == ' '){
                spaces++;
                if(sb.Length > 0){
                    words.Add(sb.ToString());
                    sb.Clear();
                }
            }else{
                sb.Append(ch);
            }
        }
        if(sb.Length > 0) words.Add(sb.ToString());
        
        sb.Clear();
        var spacesBetween = spaces/Math.Max((words.Count - 1), 1);
        var spacesAtEnd = spaces - (spacesBetween*(words.Count - 1));
        
        for(var j = 0; j < words.Count; j++){
            var word = words[j];
            sb.Append(word);
            if(j == words.Count - 1) continue;
            var currentSpaces = 0;
            while(currentSpaces++ != spacesBetween){
                sb.Append(" ");
            }
        }
        
        while(spacesAtEnd-- != 0){
            sb.Append(" ");
        }
        return sb.ToString();
    }
}
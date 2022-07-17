public class Solution {
    public int WordsTyping(string[] sentence, int rows, int cols) {
        var sb = new StringBuilder();
        foreach(var word in sentence){
            sb.Append(word);
            sb.Append(" ");
        }
        var sentenceStr = sb.ToString();
        var cursor = 0;
        var len = sentenceStr.Length;
        for(int i = 0; i < rows; i++){
            cursor += cols;
            if(sentenceStr[cursor % len] == ' '){
                ++cursor;
            }else{
                while(cursor >= 0 && sentenceStr[cursor % len] != ' '){
                    cursor--;
                }
                cursor++;
            }
        }
        return cursor / len;
    }
}
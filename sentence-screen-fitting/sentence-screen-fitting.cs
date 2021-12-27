public class Solution {
    public int WordsTyping(string[] words, int rows, int cols) {
        var sentence = string.Join(" ", words);
        sentence += " ";
        
        var len = sentence.Length;
        var cursor = 0;
        for(int row = 0; row < rows; ++row){
            cursor += cols;
            if(sentence[cursor % len] == ' '){
                ++cursor; //move on to next row safely as last word fit
            }else{
                // move back till the last complete word
                while(cursor >= 0 && sentence[cursor % len] != ' '){
                    --cursor;
                }
                ++cursor;
            }
        }
        return cursor/len;
    }
}
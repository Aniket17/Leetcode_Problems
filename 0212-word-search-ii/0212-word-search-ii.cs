public class Solution {
    public IList<string> FindWords(char[][] board, string[] words) {
        List<string> list = new List<string>();
        for(int i=0; i<words.Length; i++){
            if(exist(board, words[i])) list.Add(words[i]);
        }    
        return list;
    }

    public bool exist(char[][] board, string word) {
        for(int i=0; i<board.Length; i++){
            for(int j=0; j<board[0].Length; j++){
                char ch = word[0];
                if(board[i][j] == ch){
                    if(helper(i, j, board, word, 1)){
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool helper(int r, int c, char[][] board, string word, int count){
        if(count == word.Length){
            return true;
        }
        char currChar = board[r][c];
        board[r][c] = '!';
        char nextChar = word[count];

        //up
        if(r>0 && board[r-1][c] == nextChar){
            if(helper(r-1, c, board, word, count+1)){
                board[r][c] = currChar;
                return true;
            }
        }
        //down
        if(r<board.Length-1 && board[r+1][c] == nextChar){
            if(helper(r+1, c, board, word, count+1)){
                board[r][c] = currChar;
                return true;
            }
        }
        //left
        if(c>0 && board[r][c-1] == nextChar){
            if(helper(r, c-1, board, word, count+1)){
                board[r][c] = currChar;
                return true;
            }
        }
        //right
        if(c<board[0].Length-1 && board[r][c+1] == nextChar){
            if(helper(r, c+1, board, word, count+1)){
                board[r][c] = currChar;
                return true;
            }
        }
        board[r][c] = currChar;
        return false;
    }
}
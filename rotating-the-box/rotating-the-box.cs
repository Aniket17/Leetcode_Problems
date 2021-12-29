public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        var m = box.Length;
        var n = box[0].Length;
        
        var newBox = new char[n][];
        for(int i = 0; i < n; i++){
            newBox[i] = new char[m];
        }
        
        // process
        for(int i = 0; i < m; i++){
            for(int j = n - 1; j >= 0; j--){
                if(box[i][j] == '#'){
                    var empty = j + 1;
                    while(empty < n && box[i][empty] == '.'){
                        empty++;
                    }
                    if(empty - 1 < n && box[i][empty - 1] == '.'){
                        box[i][j] = '.';
                        box[i][empty - 1] = '#';
                    }else if(empty < n && box[i][empty] == '.'){
                        box[i][j] = '.';
                        box[i][empty] = '#';
                    }
                }
            }
        }
        
        for(int i = m - 1; i >= 0; i--){
            CopyRow(box, i, newBox, m - i - 1);
        }
        
        return newBox;
    }
    
    private void CopyRow(char[][] box, int row, char[][] newBox, int col2){
        for(int row1 = 0; row1 < newBox.Length; row1++){
            newBox[row1][col2] = box[row][row1];
        }
    }
}
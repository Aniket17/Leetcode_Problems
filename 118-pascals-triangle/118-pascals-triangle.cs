/*
numRows -> []
1 => [1]
2 => [1,1]
3 => [1,2,1]
4 => [1,3,3,1]

for row, col => [row-2][col] + [row-2][col-1]
skip 1 and last

*/

public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> pascalsTriangle = new List<IList<int>>();
        pascalsTriangle.Add(new List<int>(){1});
        if(numRows == 1) return pascalsTriangle;
        pascalsTriangle.Add(new List<int>(){1,1});
        if(numRows == 2) return pascalsTriangle;
        
        for(int row = 3; row <= numRows; row++){
            var newRow = new List<int>(){1};
            
            for(int col = 1; col < row - 1; col++){
                newRow.Add(pascalsTriangle[row-2][col] + pascalsTriangle[row-2][col-1]);
            }
            newRow.Add(1);
            pascalsTriangle.Add(newRow);
        }
        
        return pascalsTriangle;
    }
}
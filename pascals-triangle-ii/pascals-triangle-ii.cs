public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var lastRow = new List<int>();
        rowIndex++;
        if(rowIndex == 0) return lastRow;
        lastRow.Add(1);
        if(rowIndex == 1) return lastRow;
        lastRow.Add(1);
        if(rowIndex == 2) return lastRow;
        var index = 3;
        var row = new List<int>(){1};
        while(index <= rowIndex){
            row = new List<int>(){1};
            for(int i = 1; i < index-1; i++){
                row.Add(lastRow[i] + lastRow[i-1]);
            }
            row.Add(1);
            lastRow = row;
            index++;
        }
        return row;
    }
}
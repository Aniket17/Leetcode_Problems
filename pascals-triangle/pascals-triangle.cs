public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var allRows = new List<IList<int>>(){new List<int>(){1}};
        if(numRows == 1){
            return allRows;
        }
        allRows.Add(new List<int>(){1, 1}); //second row
        if(numRows == 2){
            return allRows;
        }
        var currentRow = 2;
        while(currentRow != numRows){
            AddRow(allRows, currentRow);
            currentRow++;
        }
        return allRows;
    }
    
    private void AddRow(List<IList<int>> allRows, int rowNumber){
        var row = new List<int>(){1};
        for(int i = 1; i < rowNumber; i++)
        {
            var el = allRows[rowNumber - 1][i] + allRows[rowNumber - 1][i - 1];
            row.Add(el);
        }
        row.Add(1);
        allRows.Add(row);
        Console.Write(allRows.Count());
    }
}
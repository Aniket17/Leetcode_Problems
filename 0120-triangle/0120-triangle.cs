public class Solution {
    Dictionary<(int, int), int> memo = new();
    public int MinimumTotal(IList<IList<int>> triangle) {
        return MinimumTotal(triangle, 0, 0);
    }
    int MinimumTotal(IList<IList<int>> triangle, int row, int col){
        if(row >= triangle.Count || col >= triangle[row].Count) return int.MaxValue;
        //check memo
        if(memo.ContainsKey((row, col))) return memo[(row, col)];
        //add current value to two choices we have and return the minimum sum
        var curr = triangle[row][col];
        var col1Result = MinimumTotal(triangle, row + 1, col);
        var col2Result = MinimumTotal(triangle, row + 1, col + 1);
        if(col1Result == int.MaxValue && col2Result == int.MaxValue){
            return memo[(row, col)] = curr;
        }else if(col1Result == int.MaxValue){
            return memo[(row, col)] = col2Result + curr;
        }else{
            return memo[(row, col)] = Math.Min(curr + col1Result, curr + col2Result);
        }
    }

}
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var ans = new List<IList<int>>();
        if(numRows == 0) return ans;
        ans.Add(new List<int>{1});
        if(numRows == 1) return ans;
        ans.Add(new List<int>{1,1});
        if(numRows == 2) return ans;
        var curr = 3;
        while(curr <= numRows){
            var row = new List<int>(){1};
            var rowNum = curr;
            while(row.Count != rowNum - 1){
                var prev = ans[curr - 2];
                row.Add(prev[row.Count] + prev[row.Count - 1]);
            }
            row.Add(1);
            ans.Add(row);
            curr++;
        }
        return ans;
    }
}
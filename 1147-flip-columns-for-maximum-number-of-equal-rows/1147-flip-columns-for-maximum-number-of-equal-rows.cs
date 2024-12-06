public class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        var map = new Dictionary<string, int>();
        var ans = 0;
        for(int i = 0; i < matrix.Length; i++){
            var pattern = new StringBuilder();
            var reversePattern = new StringBuilder();
            for(int j = 0; j < matrix[0].Length; j++){
                var val = matrix[i][j];
                pattern.Append(val == 0 ? 'F' : 'T');
                reversePattern.Append(val == 1 ? 'F' : 'T');
            }
            map[pattern.ToString()] = 1 + map.GetValueOrDefault(pattern.ToString());
            map[reversePattern.ToString()] = 1 + map.GetValueOrDefault(reversePattern.ToString());
        }
        return map.Values.Max();
    }
}

/*
[0,0,1],
[0,0,0],
[1,1,1]

[0,0,0],
[0,0,1],
[1,1,0]
*/
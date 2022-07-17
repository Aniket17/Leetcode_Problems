public class Solution {
    public int MinAreaRect(int[][] points) {
        var map = new Dictionary<int, HashSet<int>>();
        foreach(var point in points){
            if(!map.ContainsKey(point[0])){
                map[point[0]] = new HashSet<int>();
            }
            map[point[0]].Add(point[1]);
        }
        var area = int.MaxValue;
        for(int i = 0; i < points.Length; i++){
            for(int j = i + 1; j < points.Length; j++){
                var x1 = points[i][0];
                var y1 = points[i][1];
                var x2 = points[j][0];
                var y2 = points[j][1];
                
                if(x1 != x2 && y1 != y2){
                    if(map[x1].Contains(y2) && map[x2].Contains(y1)){
                        area = Math.Min(area, Math.Abs(x1-x2) * Math.Abs(y1 - y2));
                    }
                }
            }
        }
        return area == int.MaxValue ? 0 : area;
    }
}
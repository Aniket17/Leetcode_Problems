public class Solution {
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) {
        var hCuts = horizontalCuts.ToList();
        var vCuts = verticalCuts.ToList();
        hCuts.Add(0);
        hCuts.Add(h);
        vCuts.Add(0);
        vCuts.Add(w);
        
        hCuts = hCuts.OrderBy(x=>x).ToList();
        vCuts = vCuts.OrderBy(x=>x).ToList();
        return (int)((FindMaxDiff(hCuts) * FindMaxDiff(vCuts))%1000000007);
    }
    
    long FindMaxDiff(List<int> cuts){
        var max = int.MinValue;
        for(int i = 1; i < cuts.Count; i++){
            max = Math.Max(max, cuts[i] - cuts[i - 1]);
        }
        return max;
    }
}
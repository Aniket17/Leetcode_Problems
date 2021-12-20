public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        Array.Sort(arr);
        var min = int.MaxValue;
        for(int i = 1; i < arr.Length; i++){
            var diff = Math.Abs(arr[i] - arr[i - 1]);
            min = Math.Min(min, diff);
        }
        var result = new List<IList<int>>();
        
        for(int i = 1; i < arr.Length; i++){
            var diff = Math.Abs(arr[i] - arr[i - 1]);
            if(diff == min){
                result.Add(new List<int>(){ arr[i - 1], arr[i]});
            }
        }
        return result;
    }
}

/*
[4,2,1,3]
[1,200,201,299,300,301]
*/
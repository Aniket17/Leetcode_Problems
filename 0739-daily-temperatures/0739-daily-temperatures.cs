public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var n = temperatures.Length;
        var stack = new Stack<int[]>();
        var res = new int[n];
        for(int i = 0; i < n; i++){
            var temp = temperatures[i];
            if(stack.Count == 0){
                stack.Push(new int[]{i, temp});
                continue;
            }
            while(stack.Count != 0 && temp > stack.Peek()[1]){
                //pop.. found new big
                var top = stack.Pop();
                var prevInd = top[0];
                res[prevInd] = i - prevInd;
            }
            stack.Push(new int[]{i, temp});
        }
        return res;
    }
}

/*
[1, 2, 3, 4, 5, 6, 7, 8]
[73,74,75,71,69,72,76,73]
[74,75,76,72,72,76,0,0]


*/
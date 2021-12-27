public class Solution {
    public int OddEvenJumps(int[] arr) {
        var n = arr.Length;
        var evens = new bool[n];
        var odds = new bool[n];
        var max = int.MinValue;
        var min = int.MaxValue;
        
        odds[n - 1] = true;
        evens[n - 1] = true;
        int count = 1;
        var dict = new Dictionary<int, HashSet<int>>();
        //preprocess
        for(int i = 0; i <= n - 1; i++){
            if(dict.ContainsKey(arr[i])){
                dict[arr[i]].Add(i);
            }else{
                dict[arr[i]] = new HashSet<int>(){i};
            }
            max = Math.Max(max, arr[i]);
            min = Math.Min(min, arr[i]);
        }
        for(int i = arr.Length - 2; i >= 0; i--){
            //first find odd jump good and then even
            odds[i] = CanJump(i, arr, evens, true, dict, min, max);
            evens[i] = CanJump(i, arr, odds, false, dict, min, max);
            if(odds[i]){
                count += 1;
            }
        }
        
        // Console.WriteLine($"odds: {String.Join(",", odds)}");
        // Console.WriteLine($"evens: {String.Join(",", evens)}");
        // Console.WriteLine($"dict: {String.Join(",", String.Join("\t", dict.Select(p=> $"{p.Key}: {String.Join(",", p.Value)}")))}");
        
        return count;
    }
    
    public bool CanJump(int i, int[] arr, bool[] other, bool isOdd, Dictionary<int, HashSet<int>> dict, int min, int max){
        // check if we have a bigger el which is just bigger.. 
        var idx = isOdd ? GetJustLarger(i, arr, dict, max) : GetJustSmaller(i, arr, dict, min);
        if(idx == -1) return false;
        else return other[idx];
    }
    
    public int GetJustLarger(int i, int[] arr, Dictionary<int, HashSet<int>> dict, int max){
        var idx = -1;
        var target = arr[i];
        for(int j = target; j <= max; j++){
            if(dict.ContainsKey(j)){
                var all = dict[j].Where(x=> x > i);
                if(all.Any()){
                    return all.FirstOrDefault();
                }
            }
        }
        return idx;
    }
    
    public int GetJustSmaller(int i, int[] arr, Dictionary<int, HashSet<int>> dict, int min){
        var idx = -1;
        var target = arr[i];
        for(int j = target; j >= min; j--){
            if(dict.ContainsKey(j)){
                var all = dict[j].Where(x=> x > i);
                if(all.Any()){
                    return all.FirstOrDefault();
                }
            }
        }
        return idx;
    }
    
}

// jump % 2 == 1
//     odd jump => can only jump to larger element, but just larger (next larger)
// else
//     even jump => can only jump to smaller element, but just smaller, (next smaller)

// input -  [5,1,3,4,2]
// odd -    [B,G,G,B,G]
// even -   [G,B,G,G,G]
        
// input - [10,13,12,14,15]

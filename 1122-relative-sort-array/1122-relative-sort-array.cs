public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        if(arr2.Length == 0){
            Array.Sort(arr1);
            return arr1;
        }
        var map = new Dictionary<int, int>();
        for(int i = 0; i < arr2.Length; i++){
            map[arr2[i]] = i;
        }
        var extraNums = new List<int>();
        var queue = new PriorityQueue<int, int>();
        foreach(var num in arr1){
            if(map.ContainsKey(num)){
                queue.Enqueue(num, map[num]);
            }else{
                extraNums.Add(num);
            }
        }
        var result = new List<int>();
        while(queue.Count != 0){
            result.Add(queue.Dequeue());
        }
        result.AddRange(extraNums.OrderBy(x=>x));
        return result.ToArray();
    }
}

/*
[2,1,4,3,9,6]
{
2: 0
1: 1
4: 2
3: 3
9: 4
6: 5
}

*/
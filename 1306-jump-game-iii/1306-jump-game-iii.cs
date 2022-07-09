public class Solution {
    HashSet<string> seen = new HashSet<string>();
    public bool CanReach(int[] arr, int start) {
        if(arr == null || !arr.Any()) return false;
        var n = arr.Length;
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        while(queue.Any()){
            var idx = queue.Dequeue();
            if(arr[idx] == 0){
                return true;
            }
            if(arr[idx] < 0) continue;
            if(idx + arr[idx] < n){
                queue.Enqueue(idx + arr[idx]);
            }
            if(idx - arr[idx] >= 0){
                queue.Enqueue(idx - arr[idx]);
            }
            arr[idx] = -arr[idx];
        }
        return false;
    }
}

/***
get i - arr[i] for every index and store it in left[]
get i + arr[i] for every index and store it in right[]
//get target pos,
find all good indices and check if 0th pos right and left are at good index

indx -  [0, 1, 2, 3, 4, 5, 6]
nums -  [4, 2, 3, 0, 3, 1, 2]
left -  [-4,-1,-1,0, 1, 4, 4]
right - [4, 3, 5, 0, 7, 6, 8]

*/
public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        return FindPickIndex(arr, 1, arr.Length-2);
    }

    int FindPickIndex(int[] arr, int low, int high){
        while(low <= high){
            var mid = low + (high - low)/2;
            if(arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1]){
                return mid;
            }else if(arr[mid] > arr[mid - 1]){
                low = mid + 1;
            }else{
                high = mid - 1;
            }
        }
            
        return low;
    }
}

/*
 0,1,2,3,4,5,6
[0,1,2,3,7,6,5]
low high mid
0   6    3
3   6    4
4   6    5
4   5    4
*/
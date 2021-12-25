public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        var left = 1;
        var right = arr.Length - 2;
        
        while(left <= right){
            var mid = left + (right - left)/2;
            if(arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1]){
                return mid;
            }else if(arr[mid] > arr[mid - 1]){
                left = mid + 1;
            }else{
                right = mid - 1;
            }
        }
            
        return left;
    }
}
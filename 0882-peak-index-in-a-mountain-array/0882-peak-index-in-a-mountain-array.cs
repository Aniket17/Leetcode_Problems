public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        //use binary search to get to peak element
        //check if low..mid is sorted asc or dsc
        //if(arr[mid] < arr[mid]) // low to mid is asc so the peak will be at right
        //if(arr[mid] > arr[mid+1]) // low to mid is desc, so the peak will be at left
        int low = 0, high = arr.Length - 1;
        while(low < high){
            int mid = low + (high - low)/2;
            if(arr[mid] < arr[mid+1]){
                low = mid+1; //we are asc part, so seach right
            }else{ 
                high = mid; //we are in dsc part, so search left
            }
        }

        return low;
    }
}
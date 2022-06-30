/*
[1,3,2,3,1]
[2,6,4,6,2] * 2

[2,4,3,5,1]

[4,8,6,10,2] * 2
use modified merge sort

*/

public class Solution {
    int count = 0;
    public int ReversePairs(int[] nums) {
        MergeSort(nums, 0, nums.Length - 1);
        return count;
    }
    
    public void MergeSort(int[] nums, int low, int high){
        if(low >= high){
            return;
        }
        var mid = low + (high - low)/2;        
        MergeSort(nums, low, mid);
        MergeSort(nums, mid + 1, high);
        Merge(nums, low, high);
    }
    public void Merge(int[] nums, int low, int high){
        var mid = low + (high - low)/2;
        var i = low;
        var j = mid + 1;
        var k = 0;
        var result = new int[high - low + 1];
        
        //modification to merge sort
        // i=> low to mid and j => mid+1 to high
        while(i <= mid){
            //for every i find j which is nums[i] > 2 * nums[j]
            while(j <= high && nums[i] > 2 * (long)nums[j]){
                j++;
            }
            // whereever the j is all the elements after j are greater than j 
            // so they will suffice the condition nums[i] > 2*nums[j]
            count += (j - (mid+1));
            i++;
        }
        
        //reset and continue with merge sort
        i = low;
        j = mid + 1;
        
        while(i <= mid && j <= high){
            if(nums[i] < nums[j]){
                result[k++] = nums[i++];
            }else if(nums[i] > nums[j]){
                result[k++] = nums[j++];
            }else{
                result[k++] = nums[j++];
            }
        }
        while(i <= mid){
            result[k++] = nums[i++];
        }
        while(j <= high){
            result[k++] = nums[j++];
        }
        
        i = low;
        for(int c = 0; c < result.Length; c++){
            nums[i++] = result[c];
        }
    }
}
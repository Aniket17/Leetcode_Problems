public class Solution {
    public bool ValidMountainArray(int[] arr) {
        var i = 0;
        while(i < arr.Length && i + 1 < arr.Length && arr[i] < arr[i+1]){
            i++;
        }
        
        if(i == 0 || i >= arr.Length - 1) return false;
        
        while(i < arr.Length && i + 1 < arr.Length){
            if(arr[i] <= arr[i+1]){
                return false;
            }
            i++;
        }
        return true;
    }
}
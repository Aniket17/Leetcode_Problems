public class Solution {
    int numberOfColors = 3;
    public void SortColors(int[] nums) {
        var countMap = new int[numberOfColors];
        foreach(var n in nums){
            countMap[n]++;
        }
        
        var i = 0;
        for(int c = 0; c < numberOfColors; c++){
            while(countMap[c] > 0){
                nums[i++] = c;
                countMap[c]--;
            }
        }
    }
}
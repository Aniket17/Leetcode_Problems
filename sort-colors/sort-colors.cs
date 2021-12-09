public class Solution {
    int numberOfColors = 3;
    public void SortColors(int[] nums) {
        var counts = new int[numberOfColors];
        for(int i = 0; i < nums.Length; i++){
            counts[nums[i]]++;
        }
        var currentColor = 0;
        var lastPos = 0;
        while(currentColor < numberOfColors){
            var totalObjects = counts[currentColor];
            while(totalObjects > 0){
                nums[lastPos] = currentColor;
                totalObjects--;
                lastPos++;
            }
            currentColor++;
        }
    }
}

/*
[2,0,2,1,1,0]

counts => [2,2,2]

currentColor totalObjects   lastPos nums
0               2               0   [0,0]
1               2               2   [0,0,1,1]
2               2               4   [0,0,1,1,2,2]

*/
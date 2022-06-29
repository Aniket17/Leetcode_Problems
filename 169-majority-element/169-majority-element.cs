/*
store freq in dictionary
keep track of max
*/
public class Solution {
    public int MajorityElement(int[] nums) {
        int currentMax = int.MinValue;
        int maxElement = 0;
        
        var map = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            if(!map.ContainsKey(nums[i])){
                map.Add(nums[i], 1);
            }else{
                map[nums[i]]++;
            }
            
            if(currentMax < map[nums[i]]){
                currentMax = map[nums[i]];
                maxElement = nums[i];
            }
            
        }
        return maxElement;
    }
}
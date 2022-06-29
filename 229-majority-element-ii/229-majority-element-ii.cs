public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        HashSet<int> set = new HashSet<int>();
        
        foreach(int num in nums){
            map[num] = map.GetValueOrDefault(num) + 1;
            if(map[num] > nums.Length/3){
                set.Add(num);
            }
        }
        return set.ToList();
    }
}
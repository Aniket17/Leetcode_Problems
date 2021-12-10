public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach(int num in nums){
            map[num] = map.GetValueOrDefault(num) + 1;
        }
        return map.Where(x=>x.Value > nums.Length/3).Select(x=>x.Key).ToList();
    }
}
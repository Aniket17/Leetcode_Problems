public class Solution {
    public int[] AnagramMappings(int[] nums1, int[] nums2) {
        var map = new Dictionary<int, List<int>>();
        for(int i = 0; i < nums2.Length; i++){
            if(!map.ContainsKey(nums2[i])){
                map[nums2[i]] = new List<int>();
            }
            map[nums2[i]].Add(i);
        }
        var indexMap = new int[nums1.Length];
        for(int i = 0; i < nums1.Length; i++){
            indexMap[i] = map[nums1[i]].First();
        }
        return indexMap;
    }
}
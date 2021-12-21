public class Solution {
    public int[] AnagramMappings(int[] nums2, int[] nums1) {
        var map = new Dictionary<int, HashSet<int>>();
        for(int i = 0; i < nums1.Length; i++){
            if(map.ContainsKey(nums1[i])){
                map[nums1[i]].Add(i);
            }else{
                map[nums1[i]] = new HashSet<int>(){ i };    
            }
        }
        
        var ans = new int[nums1.Length];
        for(int i = 0; i < nums2.Length; i++){
            ans[i] = map[nums2[i]].ElementAt(0);
            map[nums2[i]].Remove(ans[i]);
        }
        return ans;
    }
}
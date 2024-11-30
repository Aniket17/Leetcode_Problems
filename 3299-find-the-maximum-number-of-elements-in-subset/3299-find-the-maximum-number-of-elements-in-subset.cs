public class Solution {
    public int MaximumLength(int[] nums) {
        var dic = CreateDicForMaximumLength(nums);
        var rs = 1;
        foreach (var item in dic)
        {
            var rs0 = 0;
            long key = item.Key;
            var hasMid = false;
            while (dic.ContainsKey(key))
            {
                if (key == 1)
                {
                    rs0 = (dic[key] / 2) * 2;
                    if (dic[key] % 2 == 1) hasMid = true;
                    break;
                }
                if (dic[key] > 1)
                {
                    rs0 += 2;
                    key *= key;
                }
                else
                {
                    hasMid = true;
                    break;
                }
            }
            rs0 += hasMid ? 1 : -1;
            rs = Math.Max(rs, rs0);
        }
        return rs;
    }
    private Dictionary<long, int> CreateDicForMaximumLength(int[] nums)
    {
        var rs = new Dictionary<long, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!rs.ContainsKey(nums[i]))
            {
                rs.Add(nums[i], 1);
            }
            else
            {
                rs[nums[i]]++;
            }
        }
        return rs;
    }
}
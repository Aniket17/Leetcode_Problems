public class Solution {
    public int MaximumLength(int[] nums) {
        int max = 1;
        Dictionary<int, int> d = new Dictionary<int, int>();
        
        foreach(int num in nums)
        {
            if(!d.ContainsKey(num)) d.Add(num, 1);
            else    d[num] = d[num] + 1;
        }

        foreach(var el in d)
        {

            int len = 0;
            int key = el.Key;

            while(d.ContainsKey(key))
            {
                int count = d[key];

                if(key == 1) break;

                if(count >= 2)
                {
                    len++;
                }
                else if(count >= 1)
                {
                    len++;
                    break;
                }

                key = key * key;
            }

            if(len > max) max = len;
        }

        if(d.ContainsKey(1))
        {
            if(d[1] % 2 == 1 && d[1] > max) return d[1];
            if(d[1] % 2 == 0 && d[1] - 1 > max) return d[1] - 1;
        }

        return max + max - 1;
    }
}
public class Solution {
    int[] reverse = new int[]{0, 1, -1, -1, -1, -1, 9, -1, 8, 6};
    int[] num = new int[]{0, 1, 6, 8, 9};
    int count = 0;
    
    public int ConfusingNumberII(int N)
    {
        dfs(0, N);
        return count;
    }
    
    private void dfs(long cur, int n)
    {
        if (cur > n)
            return;
        if (cur <= n && valid(cur))
            count++;
        
        for (int i = 0; i < num.Length; i++)
        {
            if (i == 0 && cur == 0)
                continue;
            dfs(cur * 10 + num[i], n);
        }
    }
    
    private bool valid(long n)
    {
        long tmp = n;
        long rotate = 0;
        while(tmp != 0)
        {
            int digit = (int)tmp % 10;
            if(reverse[digit] < 0)
            {
                return false;
            } 
            else 
            {
                rotate = rotate * 10 + reverse[digit];
            }
            tmp = tmp / 10;
        }
        return rotate != n;
    }    
}
public class Solution {
    public int MaxDistToClosest(int[] seats) {
        int N = seats.Length;
        int[] left = new int[N], right = new int[N];
        Array.Fill(left, N);
        Array.Fill(right, N);

        for (int i = 0; i < N; ++i) {
            if (seats[i] == 1) left[i] = 0;
            else if (i > 0) left[i] = left[i-1] + 1;
        }

        for (int i = N-1; i >= 0; --i) {
            if (seats[i] == 1) right[i] = 0;
            else if (i < N-1) right[i] = right[i+1] + 1;
        }

        int ans = 0;
        for (int i = 0; i < N; ++i)
            if (seats[i] == 0)
                ans = Math.Max(ans, Math.Min(left[i], right[i]));
        return ans;
    }
}

/*
index:[0,1,2,3,4,5,6]
orgin:[1,0,0,0,1,0,1]
left :[0,0,0,0,4,4,6]
right:[0,4,4,4,4,6,6]
ans. :[0,1,2,1,0,1,0]
*/
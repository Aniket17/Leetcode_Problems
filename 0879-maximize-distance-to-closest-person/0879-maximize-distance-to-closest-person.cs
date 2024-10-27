public class Solution {
    public int MaxDistToClosest(int[] seats) {
        var n = seats.Length;
        var rightSeats = new int[n];
        var leftSeats = new int[n];
        leftSeats[0] = seats[0] == 0 ? n - 1 : 0;
        rightSeats[n-1] = seats[n-1] == 0 ? n - 1 : 0;

        for(int i = 1; i < n; i++){
            leftSeats[i] = seats[i] == 0 ? leftSeats[i-1]+1 : 0;
        }
        for(int i = n-2; i >= 0; i--){
            rightSeats[i] = seats[i] == 0 ? rightSeats[i+1]+1 : 0;
        }
        // Console.WriteLine($"left: {string.Join(",", leftSeats)}");
        // Console.WriteLine($"right: {string.Join(",", rightSeats)}");
        var maxDist = 0;
        for(int i = 0; i < n; i++){
            maxDist = Math.Max(maxDist, Math.Min(leftSeats[i], rightSeats[i]));
        }
        return maxDist;
    }
}

/*
[1,0,0,0,1,0,1]
r[0,3,2,1,0,1,0]
l[0,1,2,3,0,1,0]

[1,0,0,0]
r[0,3,2,3]
l[0,1,2,3]

*/
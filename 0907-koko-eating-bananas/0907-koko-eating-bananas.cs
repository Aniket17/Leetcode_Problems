public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        /*
        [3,6,7,11], h = 8
        left=1 right=11 => mid = 6
        left=1 right=5 => mid = 3
        left=4 right=6 => mid = 4

        [30,11,23,4,20], h = 5
        left=1 right=30 => mid = 15
        left=16 right=30 => mid = 23
        left=24 right=30 => mid = 27
        left=28 right=30 => mid = 29
        left=30 right=30 => mid = 30
        */
        long left = 1;
        long right = piles.Max(x=>x);
        long mid = (left/2 + right/2);
        long hoursToFinish = GetHoursGivenSpeed(piles, speed: mid);
        while(left <= right){
            mid = (left + right)/2;
            hoursToFinish = GetHoursGivenSpeed(piles, speed: mid);
            if(hoursToFinish <= h){
                right = mid - 1;
            }else{
                left = mid + 1;
            }
            Console.WriteLine($"{left}, {mid}, {right}, {hoursToFinish}, {h}");
        }
        return (int)left;
    }

    long GetHoursGivenSpeed(int[] piles, long speed){
        return (long)piles.Select(x=>Math.Ceiling((double)x/speed)).Sum(x=>x);
    }
}
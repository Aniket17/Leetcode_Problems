/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int lower = 1, higher = n;
        while(lower <= higher){
            var mid = lower + (higher-lower)/2;
            if(IsBadVersion(mid)){
                //all right are bad
                higher = mid - 1;
            }else{
                lower = mid + 1;
            }
        }
        return lower;
    }
}
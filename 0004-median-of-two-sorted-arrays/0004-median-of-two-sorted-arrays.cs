public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        /*
            Pick the Smaller Array:
            Start by picking the smaller of the two arrays. This will make our search more efficient, because we’ll only need to look in the smaller array.
            Let’s call this smaller array nums1 and the larger array nums2.
        */
        int m = nums1.Length, n = nums2.Length;
        if(m > n){ return FindMedianSortedArrays(nums2, nums1); }

        int low = 0;
        int high = m;
        while(low <= high){
            /*
                partitionX = (low + high) / 2: This gives the partition point for nums1 by dividing the search space in half at each step.
                partitionY = (m + n + 1) / 2 - partitionX: This calculates the corresponding partition in nums2. 
                    The goal is to balance the number of elements on the left and right sides between the two arrays, 
                    ensuring both halves have equal (or nearly equal) numbers of elements.
                Key Insight: (m + n + 1) / 2 ensures that the combined left half has more elements if the total length is odd. 
                    The formula ensures correct partitioning between nums1 and nums2 based on how we split nums1.
            
            */
            var partitionX = (low + high)/2;
            var partitionY = (m + n + 1)/2 - partitionX;

            /*
                leftX and leftY: These represent the largest values on the left side of the partitions in nums1 and nums2, respectively.
                     If the partition is at the start of either array, we use int.MinValue as a placeholder since there are no elements on the left.

                rightX and rightY: These represent the smallest values on the right side of the partitions in nums1 and nums2. 
                    If the partition is at the end of either array, we use int.MaxValue to simulate the absence of elements on the right.
            */
            var leftX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
            var leftY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];

            var rightX = partitionX == m ? int.MaxValue : nums1[partitionX];
            var rightY = partitionY == n ? int.MaxValue : nums2[partitionY];

            if(leftX <= rightY && leftY < rightX){
                /*
                    This is the core condition to check whether the current partition is valid.
                    leftX <= rightY ensures that the largest element on the left side of nums1 is smaller than or equal to the smallest element on the right side of nums2.
                    leftY <= rightX ensures that the largest element on the left side of nums2 is smaller than or equal to the smallest element on the right side of nums1.
                */
                //found the median
                if ((m + n) % 2 == 0) {
                    return ((double)Math.Max(leftX, leftY) + Math.Min(rightX, rightY))/2;
                } else {
                    return (double)Math.Max(leftX, leftY);
                }
            }
            /*
                If leftX > rightY, it means the partition in nums1 is too far right, so we adjust the binary search to the left (high = partitionX - 1).
                If leftY > rightX, it means the partition in nums1 is too far left, so we adjust the binary search to the right (low = partitionX + 1).
            */
            else if(leftX > rightY){
                // move left
                high = partitionX - 1;
            }else{
                //move right
                low = partitionX + 1;
            }
        }
        throw new Exception("arrays are not sorted");
    }
}
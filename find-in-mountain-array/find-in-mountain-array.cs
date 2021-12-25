/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    
    Dictionary<int, int> memo = new Dictionary<int, int>();
    
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        //find pivot
        var left = 1;
        var right = mountainArr.Length() - 2;
        int elMid = 0, elMidLeft = 0, elMidRight = 0;
        var pivot = left;
        var elPivot = -1;
        while(left <= right){
            var mid = left + (right - left)/2;
            
            elMid = Get(mid, mountainArr);
            elMidLeft = Get(mid - 1, mountainArr);
            elMidRight = Get(mid + 1, mountainArr);
            
            if(elMid > elMidLeft && elMid > elMidRight){
                //found pivot
                pivot = mid;
                elPivot = elMid;
                break;
            }else if(elMid > elMidLeft){
                left = mid + 1;
            }else{
                right = mid - 1;
            }
        }
        
        var ans = -1;
        if(target == elPivot){
            return pivot;
        }
        if(target < elPivot){
            //search left
            ans = SearchAsc(target, mountainArr, 0, pivot);
        }
        
        if(ans != -1) return ans;
        // search right
        ans = SearchDesc(target, mountainArr, pivot + 1, mountainArr.Length() - 1);
        return ans;
    }
    
    private int SearchAsc(int target, MountainArray mountainArr, int left, int right){
        if(left > right) return -1;
        
        var mid = left + (right - left)/2;
        var elLeft = Get(left, mountainArr);
        if(elLeft == target){
            return left;
        }
        var elRight = Get(right, mountainArr);
        if(elRight == target){
            return right;
        }
        var elMid = Get(mid, mountainArr);
        if(elMid == target){
            return mid;
        }else if(elMid < target){
            return SearchAsc(target, mountainArr, mid + 1, right);
        }
        return SearchAsc(target, mountainArr, left, mid - 1);
    }
    
    private int SearchDesc(int target, MountainArray mountainArr, int left, int right){
        if(left > right) return -1;
        var elLeft = mountainArr.Get(left);
        if(elLeft == target){
            return left;
        }
        var elRight = mountainArr.Get(right);
        if(elRight == target){
            return right;
        }
        var mid = left + (right - left)/2;
        var elMid = mountainArr.Get(mid);
        if(elMid == target){
            return mid;
        }else if(elMid > target){
            return SearchDesc(target, mountainArr, mid + 1, right);
        }
        return SearchDesc(target, mountainArr, left, mid - 1);
    }
    
    private int Get(int index, MountainArray mountainArr){
        if(memo.ContainsKey(index)) return memo[index];
        return memo[index] = mountainArr.Get(index);
    }
    
}
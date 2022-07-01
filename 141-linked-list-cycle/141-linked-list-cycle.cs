/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */

/*
tortoise hare method =>T O(N) S O(1)
hashset method => T O(N) S O(N)
*/
public class Solution {
    public bool HasCycle(ListNode head) {
        var set = new HashSet<ListNode>();
        while(head != null){
            if(!set.Add(head)) return true;
            head = head.next;
        }
        return false;
    }
}
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
        if(head == null) return false;
        var tortoise = head;
        var hare = head;
        while(hare.next != null && hare.next.next != null){
            hare = hare.next.next;
            tortoise = tortoise.next;
            if(tortoise == hare) return true;
        }
        return false;
    }
}
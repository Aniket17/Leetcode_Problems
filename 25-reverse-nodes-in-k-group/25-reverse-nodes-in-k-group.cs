/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        if(head == null || k == 1) return head;
        
        var dummy = new ListNode(0, head);
        ListNode prev = dummy;
        ListNode next = dummy;
        ListNode curr = dummy;
        var len = 0;
        while(curr.next != null){
            curr = curr.next;
            len++;
        }
        
        while(len >= k){
            curr = prev.next;
            next = curr.next;
            for(int i = 1; i < k; i++){
                curr.next = next.next;
                next.next = prev.next;
                prev.next = next;
                next = curr.next;
            }
            prev = curr;
            len -= k;
        }
        return dummy.next;
    }
}
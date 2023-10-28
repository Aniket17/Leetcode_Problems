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
    public void ReorderList(ListNode head) {
        var dummy = head;
        int len = 0;
        while(dummy != null){
            dummy = dummy.next;
            len++;
        }
        dummy = head;
        var i = 0;
        ListNode prev = null;
        while(i <= len/2){
            prev = dummy;
            dummy = dummy.next;
            i++;
        }
        prev.next = null; //break the two lists
        var l1 = head;
        var l2 = ReverseList(dummy);
        
        while(l1 != null && l2 != null){
            var next1 = l1.next;
            var next2 = l2.next;
            
            l1.next = l2;
            l2.next = next1;
            l1 = next1;
            l2 = next2;
        }
    }

    ListNode ReverseList(ListNode head) {
        if(head == null || head.next == null) return head;
        ListNode curr = head.next, prev = head;
        while(curr != null){
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        head.next = null;
        return prev;
    }
}
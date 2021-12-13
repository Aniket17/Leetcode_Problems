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
    public ListNode RotateRight(ListNode head, int k) {
        if(head == null || head.next == null) return head;
        var n = 1;
        var temp = head;
        while(temp.next != null){
            n++;
            temp = temp.next;
        }
        if(n == k) return head;
        
        temp.next = head;
        
        var rotations = n < k ? (k % n) : k;
        temp = head;
        var newStart = n - rotations;
        
        while(--newStart > 0){
            temp = temp.next;
        }
        //now temp is pointing to new head;
        var newHead = temp.next;
        temp.next = null;
        
        var newTemp = newHead;
        while(newTemp != null){
            newTemp = newTemp.next;
        }
        return newHead;
    }
}
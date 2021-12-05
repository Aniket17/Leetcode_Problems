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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        //move runner n nodes ahead
        //move slow by 1 until runner reaches end
        if(head == null || head.next == null) return  null;
        var runner = head;
        var slow = head;
        while(n > 0){
            runner = runner.next;
            n--;
        }
        if(runner == null){
            return head.next;
        }
        var prev = slow;
        while(runner != null){
            runner = runner.next;
            prev = slow;
            slow = slow.next;
        }
        prev.next = slow.next;
        return head;
    }
}
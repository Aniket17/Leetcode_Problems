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
    public ListNode MiddleNode(ListNode head) {
        if(head == null) return head;
        var temp = head;
        var runner = head.next;
        
        while(runner != null){
            temp = temp.next;
            runner = runner.next?.next;
        }
        return temp;
    }
}
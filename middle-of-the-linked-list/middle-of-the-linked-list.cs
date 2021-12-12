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
        var runner = head;
        var temp = head;
        while(runner?.next != null){
            temp = temp.next;
            runner = runner.next.next;
        }
        return temp;
    }
}
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
        if(head == null) return head;
        //calc len
        var len = 0;
        var dummy = head;
        while(dummy!= null){
            len++;
            dummy = dummy.next;
        }
        if(len == n) return head.next;
        //go to len-n => curr
        var curr = head;
        var pos = len-n;
        Console.WriteLine(pos);
        while(pos > 1){
            curr = curr.next;
            pos--;
        }
        curr.next=curr.next.next;

        return head;
    }
}
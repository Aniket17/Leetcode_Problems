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
    public ListNode ReverseList(ListNode head) {
        /*
        next = curr.next;
        curr.next = prev
        curr = next
        prev = curr
        [1,2,3,4,5]
        [1,2,3,4,5]
        prev, curr, next
        1      2     3    2=><=1
        2      3     4   3=>2=><=1
        3      4     5   4=>3=>2=><=1
        4      5     N   5=>4=>3=>2=><=1
        5      N         
        */
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
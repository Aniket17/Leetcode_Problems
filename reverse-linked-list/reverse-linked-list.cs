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
        if (head == null || head.next == null) {
            return head;
        }
        ListNode p = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return p;
    }
}

/*
[1,2,3,4,5]

f s ret
1 2
2 3 
3 4 
4 5 
5 n 5->n
n ? n    

*/
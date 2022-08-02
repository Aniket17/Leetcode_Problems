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
    public ListNode SwapPairs(ListNode head) {
        if(head == null) return head;
        var dummy = new ListNode(0, head);
        var prev = dummy;
        var curr = prev.next;
        var shouldSwap = true;
        while(curr.next != null){
            if(shouldSwap){
                var next = curr.next;
                var nextNext = next.next;
                curr.next = nextNext;
                next.next = curr;
                prev.next = next;
                prev = next;
                curr = prev.next;
            }else{
                prev = curr;
                curr = curr.next;
            }
            shouldSwap = !shouldSwap;
        }
        
        return dummy.next;
    }
}

/*
0 [2,1,3,4]
next = node.next
nextnext = next.next
node.next = nextnext
curr.next = next
curr = next

*/
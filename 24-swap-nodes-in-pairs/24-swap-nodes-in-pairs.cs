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
        ListNode tempNode = new ListNode(-1, head);
        ListNode prevNode = tempNode;
        
        while(prevNode.next!=null && prevNode.next.next!=null)
        {
            ListNode firstNode = prevNode.next;
            ListNode secondNode= prevNode.next.next;
            
            firstNode.next = secondNode.next;
            secondNode.next = firstNode;
            
            prevNode.next = secondNode;
            
            /*resetting the value for prevNode for iteraton*/
            prevNode = firstNode;
        }
        return tempNode.next;
    }
}
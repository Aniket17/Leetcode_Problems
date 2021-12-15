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
    public ListNode InsertionSortList(ListNode head) {
        ListNode newHead = null;
        while(head != null){
            newHead = Insert(newHead, head.val);
            head = head.next;
        }
        return newHead;
    }
    
    private ListNode Insert(ListNode head, int val){
        var newNode = new ListNode(val);
        if(head == null){
            head = newNode;
            return head;
        }
        if(head.val > val){
            newNode.next = head;
            return newNode;
        }
        var temp = head;
        while(temp.next != null && temp.next.val <= val){
            temp = temp.next;
        }
        if(temp.next == null){
            temp.next = newNode;
            return head;
        }
        var next = temp.next;
        newNode.next = next;
        temp.next = newNode;
        return head;
    }
}
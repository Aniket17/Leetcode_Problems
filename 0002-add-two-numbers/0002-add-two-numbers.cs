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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var head = new ListNode();
        var result = head;
        var carry = 0;
        while(l1!=null && l2!=null){
            var sum = l1.val + l2.val + carry;
            carry = sum/10;
            head.next = new ListNode(sum%10);
            head = head.next;

            l1 = l1.next;
            l2 = l2.next;
        }
        while(l1!=null){
            var sum = l1.val + carry;
            carry = sum/10;
            head.next = new ListNode(sum%10);
            head = head.next;
            l1 = l1.next;
        }

        while(l2!=null){
            var sum = l2.val + carry;
            carry = sum/10;
            head.next = new ListNode(sum%10);
            head = head.next;
            l2 = l2.next;
        }
        if(carry > 0){
            head.next = new ListNode(1);
            head = head.next;
        }
        return result.next;
    }
}
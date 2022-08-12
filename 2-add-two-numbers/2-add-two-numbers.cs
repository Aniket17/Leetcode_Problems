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

/*
[9,9,9,9,9,9,9]
[9,9,9,9]
[8,9,9,9,0,0,0]
*/
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var carry = 0;
        var result = new ListNode(0);
        var dummy = result;
        while(l1 != null && l2 != null){
            var sum = l1.val + l2.val + carry;
            carry = sum / 10;
            result.next = new ListNode(sum % 10);
            l1 = l1.next;
            l2 = l2.next;
            result = result.next;
        }
        while(l1 != null){
            var sum = l1.val + carry;
            carry = sum / 10;
            result.next = new ListNode(sum % 10);
            l1 = l1.next;
            result = result.next;
        }
        while(l2 != null){
            var sum = l2.val + carry;
            carry = sum / 10;
            result.next = new ListNode(sum % 10);
            l2 = l2.next;
            result = result.next;
        }
        if(carry != 0){
            result.next = new ListNode(carry);
        }
        return dummy.next;
    }
}
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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2){
        
        ListNode result = new ListNode();
        var tempResult = result;
        int carry = 0;
        while(l1 != null || l2 != null){
            var sum = (l1?.val??0) + (l2?.val??0) + carry;
            carry = sum / 10;
            sum = sum % 10;
            tempResult.next = new ListNode(sum);
            tempResult = tempResult.next;
            if(l1 != null){
                l1 = l1.next;
            }
            if(l2 != null){
                l2 = l2.next;
            }
        }

        if(carry > 0){
            tempResult.next = new ListNode(carry);
        }
        return result.next;
    }
}
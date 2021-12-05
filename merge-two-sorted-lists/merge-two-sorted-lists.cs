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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        var result = new ListNode();
        var dummy = result;
        while(l1 != null && l2 != null){
            if(l1.val <= l2.val){
                result.next = new ListNode(l1.val);
                l1 = l1.next;
            }else{
                result.next = new ListNode(l2.val);
                l2 = l2.next;
            }
            result = result.next;
        }
        if(l1 != null){
            result.next = l1;
        }else if(l2 != null){
            result.next = l2;
        }
        return dummy.next;
    }

}
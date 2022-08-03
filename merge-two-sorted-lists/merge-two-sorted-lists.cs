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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null && list2 == null) return null;
        if(list1 == null) return list2;
        if(list2 == null) return list1;
        var list3 = new ListNode(0);
        var dummy = list3;
        while(list1 != null && list2 != null){
            list3.next = new ListNode(Math.Min(list1.val, list2.val));
            list3 = list3.next;
            if(list1.val < list2.val){
                list1 = list1.next;
            }else if(list1.val > list2.val){
                list2 = list2.next;
            }else{
                list3.next = new ListNode(list1.val);
                list3 = list3.next;
                list1 = list1.next;
                list2 = list2.next;
            }
        }
        if(list1 != null){
            list3.next = list1;
        }
        if(list2 != null){
            list3.next = list2;
        }
        return dummy.next;
    }
}
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
        if(list1 == null) return list2;
        if(list2 == null) return list1;
        var node = new ListNode(0, null);
        var tmp = node;
        while(list1 != null && list2 != null){
            if(list1.val < list2.val){
                node.next = new ListNode(list1.val);
                list1 = list1.next;
            }else if(list1.val > list2.val){
                node.next = new ListNode(list2.val);
                list2 = list2.next;
            }else{
                node.next = new ListNode(list1.val);
                node.next.next = new ListNode(list2.val);
                list1 = list1.next;               
                list2 = list2.next;
                node = node.next;
            }
            node = node.next;
        }
        
        while(list1 != null){
            node.next = new ListNode(list1.val);
            node = node.next;
            list1 = list1.next;
        }
        while(list2 != null){
            node.next = new ListNode(list2.val);
            node = node.next;
            list2 = list2.next;
        }
        
        return tmp.next;
    }
}
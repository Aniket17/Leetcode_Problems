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
    public ListNode MergeKLists(ListNode[] lists) {
        var k = lists.Length;
        if(k < 2) return lists.FirstOrDefault();
        var result = Merge(lists[0], lists[1]);
        for(int i = 2; i < k; i++){
            result = Merge(result, lists[i]);
        }
        return result;
    }
    
    private ListNode Merge(ListNode n1, ListNode n2){
        if(n1 == null && n2 == null) return null;
        if(n1 == null) return n2;
        if(n2 == null) return n1;
        if(n1.val < n2.val){
            n1.next = Merge(n1.next, n2);
            return n1;
        }else{
            n2.next = Merge(n1, n2.next);
            return n2;
        }
    }
}
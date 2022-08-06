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
        var result = new ListNode(0);
        var temp = result;
        while(n1 != null && n2 != null){
            result.next = new ListNode(Math.Min(n1.val, n2.val));
            result = result.next;
            if(n1.val < n2.val){
                n1 = n1.next;
            }else{
                n2 = n2.next;
            }
        }
        if(n1 != null){
            result.next = n1;
        }
        if(n2 != null){
            result.next = n2;
        }
        return temp.next;
    }
}
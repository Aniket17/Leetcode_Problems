/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    /*
    create a map of node=>node 
    key: node.next
    val: node
    
    iterate the list2 to check if node.next is in map, return node.next
    */
    public ListNode GetIntersectionNode(ListNode list1, ListNode list2) {
        var map = new HashSet<ListNode>();
        if(list1 == null || list2 == null) return null;
        
        while(list1 != null){
            map.Add(list1);
            list1 = list1.next;
        }
        
        while(list2 != null){
            if(map.Contains(list2)){
                return list2;
            }
            list2 = list2.next;
        }
        return null;
    }
}
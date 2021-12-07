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
    public int GetDecimalValue(ListNode head) {
        //runner technique
        var len = 0;
        var temp = head;
        while(temp != null){
            temp = temp.next;
            len++;
        }
        int ans = 0;
        temp = head;
        while(temp != null){
            ans += (temp.val * (int)Math.Pow(2, len - 1));
            temp = temp.next;
            len--;
        }
        return ans;
    }
}
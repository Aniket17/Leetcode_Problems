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
    public ListNode ReverseList(ListNode head) {
        if(head == null || head.next == null) return head;
        var curr = head;
        ListNode next, prev = null;
        while(curr != null){
            next = curr.next; // 2 -> 3 -> 4 -> 5
            curr.next = prev; // 1 -> null
            prev = curr;      // 1 -> null
            curr = next;      // 2 -> 3 -> 4 -> 5  
        }
        return prev;
    }
}


/*
1 -> 2 -> 3 -> 4 -> 5

next = curr.next // 2 -> 3 -> 4 -> 5
curr.next = prev // 1 -> null
prev = curr      // 1 -> null
curr = next      // 2 -> 3 -> 4 -> 5  

-------------------
next = curr.next // 3 -> 4 -> 5
curr.next = prev // 2 -> 1 -> null
prev = curr      // 2 -> 1 -> null
curr = next      // 3 -> 4 -> 5  

-------------------
next = curr.next // 4 -> 5
curr.next = prev // 3 -> 2 -> 1 -> null
prev = curr      // 3 -> 2 -> 1 -> null
curr = next      // 4 -> 5  

-------------------
next = curr.next // 5 -> null
curr.next = prev // 4 -> 3 -> 2 -> 1 -> null
prev = curr      // 4 -> 3 -> 2 -> 1 -> null
curr = next      // 5 -> null  

-------------------
next = curr.next // null
curr.next = prev // 5 -> 4 -> 3 -> 2 -> 1 -> null
prev = curr      // 5 -> 4 -> 3 -> 2 -> 1 -> null
curr = next      // null 

*/
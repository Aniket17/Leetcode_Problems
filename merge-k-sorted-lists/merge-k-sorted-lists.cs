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
    var len = lists.Length;
    if (len == 0) return null;
    if (len == 1) return lists[0];

    var lengths = new int[len];
    for (int i = 0; i < len - 1; i++) {
      var head = lists[i];
      var temp = head;
      var counter = 0;
      while (temp != null) {
        temp = temp.next;
        counter++;
      }
      lists[i] = head;
      lengths[i] = counter;
    }

    var tmp = new ListNode();
    var result = tmp;
    var count = len;
    while (count > 0) {
        var firsts = new Dictionary <int,int> ();
        for (int i = 0; i < len; i++) {
            if (lists[i] != null) {
                  firsts.Add(i, lists[i].val);
            } else {
                  if (lengths[i] == 0) {
                    count--;
                  }
                  lengths[i]--;
            }
        }
        if(firsts.Any()){
            int minIndex = firsts.OrderBy(k => k.Value).Select(k => k.Key).First();
            var el = lists[minIndex];
            result.next = new ListNode(el.val);
            result = result.next;
            lists[minIndex] = lists[minIndex].next;
        }
    }
    return tmp.next;
  }
}
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0) return null;

        // Apply divide and conquer approach to merge all lists
        return MergeLists(lists, 0, lists.Length - 1);
    }

    // Helper method to merge lists in a divide and conquer manner
    ListNode MergeLists(ListNode[] lists, int low, int high) {
        if (low == high) {
            return lists[low];  // Single list, return it
        }

        int mid = (low + high) / 2;

        // Recursively merge two halves
        ListNode left = MergeLists(lists, low, mid);
        ListNode right = MergeLists(lists, mid + 1, high);

        // Merge the two halves
        return MergeTwoLists(left, right);
    }

    // Helper method to merge two sorted linked lists
    ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        ListNode dummy = new ListNode();  // Placeholder for the result list
        ListNode current = dummy;

        // Merge two lists
        while (l1 != null && l2 != null) {
            if (l1.val < l2.val) {
                current.next = l1;
                l1 = l1.next;
            } else {
                current.next = l2;
                l2 = l2.next;
            }
            current = current.next;
        }

        // Append the remaining elements (if any)
        if (l1 != null) current.next = l1;
        if (l2 != null) current.next = l2;

        return dummy.next;  // Return the merged list starting from dummy.next
    }
}

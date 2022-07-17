/**
 * // This is the ImmutableListNode's API interface.
 * // You should not implement it, or speculate about its implementation.
 * class ImmutableListNode {
 *     public void PrintValue(); // print the value of this node.
 *     public ImmutableListNode GetNext(); // return the next node.
 * }
 */

public class Solution {
    public void PrintLinkedListInReverse(ImmutableListNode head) {
        var stack = new Stack<ImmutableListNode>();
        stack.Push(head);
        while(true){
            var next = head.GetNext();
            if(next == null){
                break;
            }
            stack.Push(next);
            head = next;
        }
        while(stack.Count != 0){
            stack.Pop().PrintValue();
        }
    }
}
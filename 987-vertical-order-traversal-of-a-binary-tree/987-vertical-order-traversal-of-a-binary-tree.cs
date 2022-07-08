/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root)
    {
        var list = new List<IList<int>>();
        if (root == null) return list;
        var queue = new Queue<(TreeNode node, int level)>();
        queue.Enqueue((root, 0));
        var allNodes = new List<(int val, int level)>();
        while (queue.Count != 0)
        {
            var levelNodes = new List<(int val, int level)>();
            var count = queue.Count;
            while (count-- != 0)
            {
                var tuple = queue.Dequeue();
                levelNodes.Add((val: tuple.node.val, level: tuple.level));
                if (tuple.node.left != null)
                {
                    var newTuple = (node: tuple.node.left, level: tuple.level - 1);
                    queue.Enqueue(newTuple);
                }

                if (tuple.node.right != null)
                {
                    var newTuple = (node: tuple.node.right, level: tuple.level + 1);
                    queue.Enqueue(newTuple);
                }
            }
            allNodes.AddRange(levelNodes.OrderBy(x => x.val));
        }
        var map = new Dictionary<int, List<int>>();
        foreach (var item in allNodes)
        {
            if (!map.ContainsKey(item.level)) {
                map[item.level] = new List<int>();
            }
            map[item.level].Add(item.val);
        }
        return map.OrderBy(x => x.Key).Select(x => x.Value).ToList<IList<int>>();
    }
}
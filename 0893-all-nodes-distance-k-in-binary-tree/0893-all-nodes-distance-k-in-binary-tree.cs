/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        Dictionary<TreeNode, List<TreeNode>> graph = new();
        BuildGraph(root, graph);
        //Console.WriteLine($"graph: {string.Join("\n", graph.Select(x=> $"{x.Key.val}: {string.Join(",", x.Value.Select(q=>q.val))}"))}");
        var queue = new Queue<TreeNode>();
        var seen = new HashSet<TreeNode>();
        queue.Enqueue(target);
        seen.Add(target);
        while(queue.Count != 0 && k != 0){
            var size = queue.Count;
            while(size-- != 0){
                var node = queue.Dequeue();
                //Console.WriteLine($"dequeued node: {node.val} with children: {string.Join(",", graph[node].Select(x=>x.val))}");
                foreach(var nei in graph[node]){
                    if(!seen.Add(nei)) continue;
                    queue.Enqueue(nei);
                }
            }
            k--;
        }
        var ans = new List<int>();
        if(k > 0) return ans;
        while(queue.Count != 0){
            ans.Add(queue.Dequeue().val);
        }
        return ans;
    }

    void BuildGraph(TreeNode root, Dictionary<TreeNode, List<TreeNode>> graph){
        if(!graph.ContainsKey(root)){
            graph[root] = new();
        }
        if(root.left != null){
            graph[root].Add(root.left);
            if(!graph.ContainsKey(root.left)){
                graph[root.left] = new();
            }
            graph[root.left].Add(root);
            BuildGraph(root.left, graph);
        }

        if(root.right != null){
            graph[root].Add(root.right);
            if(!graph.ContainsKey(root.right)){
                graph[root.right] = new();
            }
            graph[root.right].Add(root);
            BuildGraph(root.right, graph);
        }
    }
}
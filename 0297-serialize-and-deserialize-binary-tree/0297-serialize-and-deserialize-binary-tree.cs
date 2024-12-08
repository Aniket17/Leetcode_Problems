/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        var sb = new StringBuilder();
        if(root == null){
            return "null,";
        }
        sb.Append(root.val.ToString() + ",");
        sb.Append(serialize(root.left));
        sb.Append(serialize(root.right));
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        Console.WriteLine(data);
        return deserialize(new LinkedList<string>(data.Split(",")));
    }

    private TreeNode deserialize(LinkedList<string> data) {
        var val = data.First();
        data.RemoveFirst();
        if(val == "null"){
            return null;
        }
        TreeNode rootNode = new(int.Parse(val));
        rootNode.left = deserialize(data);
        rootNode.right = deserialize(data);
        return rootNode;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
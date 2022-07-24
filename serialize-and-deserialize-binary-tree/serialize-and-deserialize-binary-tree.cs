/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
5
4 4 
   3 3
      2 2
      
[5,4,4,n,n,3,3]
[0,1,2,3,4,5,6,11,12]
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null) return "null,";
        var sb = new StringBuilder();
        sb.Append(root.val+",");
        sb.Append(serialize(root.left));
        sb.Append(serialize(root.right));
        return sb.ToString();
    }

    public TreeNode deserialize(List<string> data){
        if(!data.Any()) return null;
        var d = data[0];
        data.RemoveAt(0);
        if(d == "null"){
            return null;
        }
        var node = new TreeNode(int.Parse(d));
        node.left = deserialize(data);
        node.right = deserialize(data);
        return node;
    }
    
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        return deserialize(data.Split(",").ToList());
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
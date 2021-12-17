public class ListNode{
        public int data;
        public int key;
        public ListNode prev;
        public ListNode next;

        public ListNode(int data = 0, int key = 0){
            this.data = data;
            this.key = key;
        }
    }

public class LRUCache {
    
    ListNode head;
    ListNode tail;
    Dictionary<int, ListNode> map;
    int capacity;
    private void Print(){
        Console.WriteLine("\n *******");
        var temp = head;
        while(temp.next != tail){
            Console.Write(temp.key+"\t");
            temp = temp.next;
        }
        Console.Write(temp.key+"\t");
        Console.WriteLine();
    }
    public LRUCache(int capacity) {
        map = new Dictionary<int, ListNode>();
        this.capacity = capacity;
        head = new ListNode();
        tail = new ListNode();
        head.next = tail;
        tail.prev = head;
    }
    
    public int Get(int key) {
        if(map.ContainsKey(key)){
            //process
            var node = map[key];
            Detach(node);
            Attach(node);
            // Console.WriteLine($"GET {key}");
            // Print();
            return node.data;
        }
        return -1;
    }
    
    public void Put(int key, int value) {
        if(map.ContainsKey(key)){
            //update
            var node = map[key];
            node.data = value;
            Detach(node);
            Attach(node);
        }else{
            //add -> capacity
            var newNode = new ListNode(value, key);
            if(map.Count == capacity){
                map.Remove(tail.prev.key);
                Detach(tail.prev);
            }
            Attach(newNode);
            map[key] = newNode;
        }
            // Console.WriteLine($"PUT {key}");
            // Print();
    }
    
    private void Attach(ListNode node){
        var next = head.next;
        node.next = next;
        node.prev = head;
        head.next = node;
        next.prev = node;
    }
    
    private void Detach(ListNode node){
        var next = node.next;
        var prev = node.prev;
        prev.next = next;
        next.prev = prev;
    }
    ///insert  -> head MSU
    // remove -> tail
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);

[{1:1}, {2:2}, {3:3}]

DLL -> 
NULL<-head->{}<->{4:4}<->{2:2}<->{3:3}<->tail->NULL


Dictionary<key, Node> => 1 -> x1
                         2 -> x4
                         3 -> x3
x2.val -> return
x2.prev.next = x2.next


["LRUCache", "put",   "put", "get", "put",   "get", "put", "get", "get", "get"]
[    [2],    [1, 1], [2, 2],  [1],  [3, 3],  [2],   [4, 4], [1],   [3],   [4]]


map [] => {1:1} -> tail
head {3:3}{1:1}  tail

*/


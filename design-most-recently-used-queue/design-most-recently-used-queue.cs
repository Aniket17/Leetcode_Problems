public class MRUQueue {
    Deque queue;
    int N;
    public MRUQueue(int n) {
        N = n;
        queue = new Deque();
        for(int i = 1; i <= n; i++){
            queue.PushBack(new ListNode(i));
        }
    }
    
    public int Fetch(int k) {
        ListNode node;
        // if(k > N/2){
        //     node = queue.GetBack(N - k);
        // }else{
        //     node = queue.GetFront(k);
        // }
        node = queue.GetFront(k);
        queue.Remove(node);
        queue.PushBack(node);
        return node.val;
    }
    
    public class ListNode{
        public int val;
        public ListNode next;
        public ListNode prev;
        public ListNode(int val){
            this.val = val;
        }
    }
    
    
    
public class Deque{
    ListNode front;
    ListNode back;
    int count;
    public Deque() {
        front = new ListNode(0);
        back = new ListNode(0);
        front.next = back;
        back.prev =  front;
    }
    
    public void PushBack(ListNode newNode){
        var last = this.back.prev;
        newNode.next = this.back;
        newNode.prev = last;
        last.next = newNode;
        this.back.prev = newNode;
        count++;
    }
    
    public ListNode GetFront(int k){
        var tmp = front;
        while(k-- > 0){
            tmp = tmp.next;
        }
        return tmp;
    }
    
    public ListNode GetBack(int k){
        var tmp = back;
        int i = 0;
        while(i++ != k){
            tmp = tmp.prev;
        }
        return tmp;
    }
    
    public void Remove(ListNode node){
        var prev = node.prev;
        var next = node.next;
        prev.next = next;
        next.prev = prev;
        node.next = null;
        node.prev = null;
        count--;
    }
    
    private void Print(){
        var tmp = front;
        while(tmp != back){
            Console.Write("\t"+tmp.val);
            tmp = tmp.next;
        }
        Console.WriteLine();
    }
    
    public int Count{get {return count;}}
}

    
    
}



/**
 * Your MRUQueue object will be instantiated and called as such:
 * MRUQueue obj = new MRUQueue(n);
 * int param_1 = obj.Fetch(k);
 */
public class Solution {
    int[] ans;
    int shelfWidth;
    Dictionary<string, int> memo = new Dictionary<string, int>();
    
    public int MinHeightShelves(int[][] books, int shelfWidth) {
        this.shelfWidth = shelfWidth;
        var list = new Book[books.Length];
        int i = 0;
        foreach(var b in books){
            list[i++] = new Book(b[0], b[1]);
        }
        return Solve(list, 0, 0, shelfWidth);
    }
    
    public int Solve(Book[] books, int pos, int currentHeight, int width){
        if(pos == books.Length){
            return currentHeight;
        }
        var key = $"{pos},{currentHeight},{width}";
        if(memo.ContainsKey(key)){
            return memo[key];
        }
        
        var book = books[pos];
        var ans = Solve(books, pos + 1, book.height, shelfWidth - book.width) + currentHeight;
        
        var canPlace = book.width <= width;
        if(canPlace){
            var ans2 = Solve(books, pos + 1, Math.Max(book.height, currentHeight), width - book.width);
            ans = Math.Min(ans, ans2);
        }
        return memo[key] = ans;
    }
    
    public class Book{
        public int height;
        public int width;
        public Book(int w, int h){
            height = h;
            width = w;
        }
    }
}

/*
start with 0th shelf => put book 1 there
for next books
    put in this or next if not fit
    OR
    put in next (nexts next)
    whoever has min height wins
    store this in list<list<book>>
*/
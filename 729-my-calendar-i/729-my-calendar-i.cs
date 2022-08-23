public class MyCalendar {
    List<Booking> _bookings;
    public MyCalendar() {
        _bookings = new();
    }
    
    public bool Book(int start, int end) {
        for(var i = 0; i < _bookings.Count; i++){
            var _booking = _bookings[i];
            if(_booking.start < end && start < _booking.end) return false;
        }
        _bookings.Add(new Booking(start, end));
        return true;
    }
    
    public class Booking{
        public int start;
        public int end;
        public Booking(int s, int e){
            start = s;
            end = e;
        }
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
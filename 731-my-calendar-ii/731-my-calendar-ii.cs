public class MyCalendarTwo {
    List<Booking> _bookings;
    List<Booking> _doubleBookings;
    public MyCalendarTwo() {
        _bookings = new();
        _doubleBookings = new();
    }
    
    public bool Book(int start, int end) {
        for(int i = 0; i < _doubleBookings.Count; i++){
            if(_doubleBookings[i].IsConflict(start, end)) return false;
        }
        
        for(int i = 0; i < _bookings.Count; i++){
            var _booking = _bookings[i];
            if(_booking.IsConflict(start, end)){
                //split it and add it
                _doubleBookings.Add(new Booking(Math.Max(start, _booking.start),
                                                Math.Min(end, _booking.end)));
            }
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
        
        public bool IsConflict(int start, int end){
            return this.start < end && start < this.end; 
        }
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */
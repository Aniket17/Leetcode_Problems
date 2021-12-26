/**
 * @param {number} n
 */
var ExamRoom = function(n) {
    this.N = n;
    this.students = [];
};

/**
 * @return {number}
 */
ExamRoom.prototype.seat = function() {
    if(this.students.length == 0){
        this.students.push(0);
        return 0;
    }
    
    let pre = -1; maxDist = this.students[0], seat = 0;
    
    for(let i = 0; i < this.students.length; i++){
        const cur = this.students[i];
        
        if(pre > -1){
            const d = Math.floor((cur - pre)/2);
            if(d > maxDist){
                maxDist = d;
                seat = pre + d;
            }
        }
        pre = cur;
    }
    
    if(this.N - 1 - this.students[this.students.length - 1] > maxDist){
        seat = this.N - 1;
    }
    
    let i = 0;
    
    while(i < this.students.length && this.students[i] < seat){
        i++;
    }
    
    this.students.splice(i, 0, seat);
    return seat;
    
};

/** 
 * @param {number} p
 * @return {void}
 */
ExamRoom.prototype.leave = function(p) {
    let i = 0;
    while(i < this.students.length && this.students[i] != p){
        i++;
    }
    this.students.splice(i,1);
};

/** 
 * Your ExamRoom object will be instantiated and called as such:
 * var obj = new ExamRoom(n)
 * var param_1 = obj.seat()
 * obj.leave(p)
 */
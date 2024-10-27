public class BrowserHistory {
    string[] history;
    int lower, upper, current;
    public BrowserHistory(string homepage) {
        history = new string[5000];
        history[0] = homepage;
        lower = 0;
        upper = 0;
        current = 0;
    }
    
    public void Visit(string url) {
        current++;
        history[current] = url;
        upper = current;
    }
    
    public string Back(int steps) {
        var maxSteps = Math.Min(steps, current-lower);
        current -= maxSteps;
        return history[current];
    }
    
    public string Forward(int steps) {
        var maxSteps = Math.Min(steps, upper-current);
        current += maxSteps;
        return history[current];
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */
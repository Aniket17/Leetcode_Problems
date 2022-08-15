public class Logger {
    Dictionary<string, int> messages;
    public Logger() {
        messages = new();
    }
    
    public bool ShouldPrintMessage(int timestamp, string message) {
        if(messages.ContainsKey(message) && messages[message] + 10 > timestamp){
            return false;
        }
        messages[message] = timestamp;
        return true;
    }
}

using System;

public class Logger
{
    // Private instance of the Logger class
    private static Logger instance;

    // Private constructor to prevent external instantiation
    private Logger()
    {
        // Initialization code, if any
        Timestamp = DateTime.Now;
    }

    // Public method to access the instance (Singleton pattern)
    public static Logger Instance
    {
        get
        {
            // If the instance is null, create a new instance
            if (instance == null)
            {
                instance = new Logger();
            }

            return instance;
        }
    }

    // Example property for demonstration
    public DateTime Timestamp { get; private set; }

    // Example method to log messages
    public void LogMessage(string message)
    {
        Console.WriteLine($"[{Timestamp}] Log: {message}");
    }
}

class Program
{
    static void Main()
    {
        // Accessing the Logger instance using the public method
        Logger logger = Logger.Instance;
        Logger logger2 = Logger.Instance;
        // Using the Logger to log messages
        logger.LogMessage("This is a log message.");
    }
}

using System;
using System.Collections.Generic;

public class ConfigurationManager
{
    // Private instance of the ConfigurationManager class
    private static ConfigurationManager instance;

    // Private constructor to prevent external instantiation
    private ConfigurationManager()
    {
        // Initialization code, if any
        Settings = new Dictionary<string, string>();
    }

    // Public method to access the instance (Singleton pattern)
    public static ConfigurationManager Instance
    {
        get
        {
            // If the instance is null, create a new instance
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }

            return instance;
        }
    }

    // Private dictionary to store configuration settings
    private Dictionary<string, string> Settings { get; set; }

    // Public method to set a configuration setting
    public void SetSetting(string key, string value)
    {
        Settings[key] = value;
    }

    // Public method to get the value of a configuration setting
    public string GetSetting(string key)
    {
        if (Settings.TryGetValue(key, out string value))
        {
            return value;
        }

        return null; // Return null if the key is not found
    }
}

class Program
{
    static void Main()
    {
        // Accessing the ConfigurationManager instance using the public method
        ConfigurationManager configManager = ConfigurationManager.Instance;

        // Setting and getting configuration settings
        configManager.SetSetting("LogLevel", "Debug");
        configManager.SetSetting("MaxConnections", "100");

        string logLevel = configManager.GetSetting("LogLevel");
        string maxConnections = configManager.GetSetting("MaxConnections");

        // Displaying configuration settings
        Console.WriteLine($"LogLevel: {logLevel}");
        Console.WriteLine($"MaxConnections: {maxConnections}");
    }
}

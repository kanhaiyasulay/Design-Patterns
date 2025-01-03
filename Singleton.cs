using System;

public class Singleton
{
    // Step 1: Create a private static instance of the class
    private static Singleton _instance;
    public int cnt = 0;

    // Step 2: Make the constructor private so it can't be called outside this class
    private Singleton() 
    {
        Console.WriteLine("Singleton Instance Created");
    }

    // Step 3: Provide a public static method to get the single instance
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }

    // Example method in Singleton
    public void DisplayMessage()
    {
        Console.WriteLine("Hello from Singleton");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Try to get Singleton instances
        Singleton s1 = Singleton.GetInstance();
        s1.DisplayMessage();
        s1.cnt++;
        
        Singleton s2 = Singleton.GetInstance();
        s2.DisplayMessage();
        Console.WriteLine(s2.cnt);

        // Check if both instances are the same
        Console.WriteLine(Object.ReferenceEquals(s1, s2)); // Output: True
    }
}

/* All implementations of the Singleton have these 3 steps in common:
1.    Make the default constructor private, to prevent other objects from using the new operator with the Singleton class.
2.    Create a static creation method `getInstance()` that acts as a constructor. Under the hood, this method calls the private constructor to create an object and saves it in a static field. All following calls to this method return the cached object. 
3.     instance for the singleton class is not created in the main method rather it is created in the class itself */

// audio manager
// event manager
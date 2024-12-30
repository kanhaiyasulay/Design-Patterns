using System;
using System.Collections.Generic;  

public interface IObserver
{
    void Update(string rampageState);
}
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
public class GameCharacter : ISubject
{
// `List<IObserver>` means that this is a list of objects that implement the IObserver interface.
    private List<IObserver> observers;
    private string rampageState;

//constructor to initiallize the list and rampage mode
    public GameCharacter()
    {
        observers = new List<IObserver>();   //initially list is empty
        rampageState = "Normal"; // Initial state
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(rampageState);
        }
    }

    // Trigger rampage mode
    public void EnterRampageMode()
    {
        rampageState = "Rampage";
        Console.WriteLine("GameCharacter: Entering Rampage Mode!");
        NotifyObservers();
    }

    public void ExitRampageMode()
    {
        rampageState = "Normal";
        Console.WriteLine("GameCharacter: Exiting Rampage Mode!");
        NotifyObservers();
    }
}
public class HealthDisplay : IObserver
{
    public void Update(string rampageState)
    {
        if (rampageState == "Rampage")
        {
            Console.WriteLine("HealthDisplay: Player is in Rampage Mode. Health is invincible.");
        }
        else
        {
            Console.WriteLine("HealthDisplay: Player is in Normal Mode. Health can be damaged.");
        }
    }
}

public class EnemyAI : IObserver
{
    public void Update(string rampageState)
    {
        if (rampageState == "Rampage")
        {
            Console.WriteLine("EnemyAI: Player is in Rampage Mode. Enemies will not attack.");
        }
        else
        {
            Console.WriteLine("EnemyAI: Player is in Normal Mode. Enemies will resume attack.");
        }
    }
}

public class PowerDisplay : IObserver
{
    public void Update(string rampageState)
    {
        if (rampageState == "Rampage")
        {
            Console.WriteLine("PowerDisplay: Special powers are activated!");
        }
        else
        {
            Console.WriteLine("PowerDisplay: Special powers are deactivated.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create the subject (GameCharacter)
        GameCharacter player = new GameCharacter();

        // Create observers
        HealthDisplay healthDisplay = new HealthDisplay();
        EnemyAI enemyAI = new EnemyAI();
        PowerDisplay powerDisplay = new PowerDisplay();

        // Register observers
        player.RegisterObserver(healthDisplay);
        player.RegisterObserver(enemyAI);
        player.RegisterObserver(powerDisplay);

        // GameCharacter enters Rampage Mode
        player.EnterRampageMode();

        // GameCharacter exits Rampage Mode
        player.ExitRampageMode();
    }
}

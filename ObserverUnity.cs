using UnityEngine;
using System.Collections.Generic;

// Interface for Observers
public interface IObserver
{
    void Update(string message);
}

// Interface for Subject
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(string message);
}

// GameNotificationSystem acts as the Subject
public class GameNotificationSystem : MonoBehaviour, ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    // Register an observer
    public void RegisterObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    // Remove an observer
    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    // Notify all observers with a message
    public void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    // Methods to simulate game events
    public void FriendAchievedHighScore(string friendName, int score)
    {
        NotifyObservers($"{friendName} scored {score} points! Can you beat them?");
    }

    public void NewChallengeAvailable(string challengeName)
    {
        NotifyObservers($"New Challenge: {challengeName} is now live! Join now.");
    }

    public void FriendWonContest(string friendName)
    {
        NotifyObservers($"{friendName} won the contest! Challenge them in the next event.");
    }

    // Simulating events on Start (for testing purposes)
    void Start()
    {
        // Example: Simulating notifications
        FriendAchievedHighScore("Juilee", 1500);
        NewChallengeAvailable("Time Attack");
        FriendWonContest("Prathamesh");
    }
}

// Player acts as an Observer
public class Player : MonoBehaviour, IObserver
{
    [SerializeField] private string playerName;

    // Set the player's name via the inspector or script
    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    // Handle updates from the Subject
    public void Update(string message)
    {
        Debug.Log($"{playerName} received notification: {message}");
    }

    // Register with the notification system on Start
    void Start()
    {
        // Find the notification system in the scene
        GameNotificationSystem notificationSystem = FindObjectOfType<GameNotificationSystem>();

        if (notificationSystem != null)
        {
            notificationSystem.RegisterObserver(this);
        }
    }

    // Unregister from the notification system on Destroy
    void OnDestroy()
    {
        GameNotificationSystem notificationSystem = FindObjectOfType<GameNotificationSystem>();

        if (notificationSystem != null)
        {
            notificationSystem.RemoveObserver(this);
        }
    }
}

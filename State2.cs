//This is not how most optimally the state pattern is implemented 
// but still this type of code is also know as state pattern
using System;

public interface IState
{
    void HandleInput(GameCharacter character, string input);
}

public class GameCharacter
{
    private IState currentState;

    public GameCharacter()
    {
        // Start with the Standing state
        currentState = new StandingState();
    }

    public void SetState(IState newState)
    {
        currentState = newState;
        Console.WriteLine($"State changed to: {currentState.GetType().Name}");
    }

    public void HandleInput(string input)
    {
        currentState.HandleInput(this, input);
    }
}

public class StandingState : IState
{
    public void HandleInput(GameCharacter character, string input)
    {
        if (input == "jump")
        {
            character.SetState(new JumpingState());
        }
        else if (input == "crouch")
        {
            character.SetState(new CrouchingState());
        }
        else
        {
            Console.WriteLine("Standing: Invalid action.");
        }
    }
}

public class JumpingState : IState
{
    public void HandleInput(GameCharacter character, string input)
    {
        if (input == "land")
        {
            character.SetState(new StandingState());
        }
        else
        {
            Console.WriteLine("Jumping: Can only land.");
        }
    }
}

public class CrouchingState : IState
{
    public void HandleInput(GameCharacter character, string input)
    {
        if (input == "stand")
        {
            character.SetState(new StandingState());
        }
        else
        {
            Console.WriteLine("Crouching: Can only stand.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GameCharacter character = new GameCharacter();

        // Test inputs
        character.HandleInput("jump");   // Standing -> Jumping
        character.HandleInput("land");   // Jumping -> Standing
        character.HandleInput("crouch"); // Standing -> Crouching
        character.HandleInput("stand");  // Crouching -> Standing
        character.HandleInput("fly");    // Invalid action
    }
}

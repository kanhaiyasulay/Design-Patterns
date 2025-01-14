using System;
using System.Collections.Generic;
namespace CommandDesignPattern
{
  public interface ICommand
  {
    void Execute();
    void Unexecute();
  }
  
  public class Light
  {
    public void TurnOn() => Console.WriteLine("Light is on!");
    public void TurnOff() => Console.WriteLine("Light is off!");
  }
  
  public class TurnOnLight : ICommand
  {
    private Light light;
    public TurnOnLight(Light light)
    {
      this.light = light;
    }
    
    public void Execute() => light.TurnOn();
    public void Unexecute() => light.TurnOff();
  }
  
  public class TurnOffLight : ICommand
  {
    private Light light;
    public TurnOffLight(Light light)
    {
      this.light = light;
    }
    
    public void Execute() => light.TurnOff();
    public void Unexecute() => light.TurnOn();
  }
  
  public class Remote
  {
    public readonly Stack<ICommand> undoStack = new Stack<ICommand>(); // used for unexecuting commands
    public readonly Stack<ICommand> redoStack = new Stack<ICommand>(); // used for re-doing unexecuted commands
    private ICommand command;
    public void SetCommand(ICommand command)
    {
      this.command = command;
    }

    public void ExecuteCommand()
    {
      if(command == null) 
      {
        Console.WriteLine("No command set");
        return;
      }
      command.Execute();
      undoStack.Push(command);
      redoStack.Clear();
    }

    public void UnexecuteCommand()
    {
      if (undoStack.Count > 0)
      {
        ICommand command = undoStack.Pop();
        command.Unexecute();
        redoStack.Push(command);
      }
      else
      {
        Console.WriteLine("Nothing to undo");
      }
    }
    public void Redo()
    {
      if(redoStack.Count > 0)
      {
        ICommand newCommand = redoStack.Pop();
        newCommand.Execute();
        undoStack.Push(newCommand);
      }
      else Console.WriteLine("Nothing to redo");
    }
  }
  
  public class Program
  {
    public static void Main(string[] args)
    {
      Light light = new Light();
      TurnOnLight turnOn = new TurnOnLight(light);
      TurnOffLight turnOff = new TurnOffLight(light);
      Remote remote = new Remote();
      
      remote.SetCommand(turnOn);
      remote.ExecuteCommand(); // light is on!
      
      remote.SetCommand(turnOff);
      remote.ExecuteCommand(); // light is off!
      
      remote.UnexecuteCommand(); // light is on!
      
      remote.Redo(); // light is off!
      remote.Redo(); // Notthing to redo
      
      remote.UnexecuteCommand();
      remote.SetCommand(turnOff);
      remote.ExecuteCommand();
    }
  }
}

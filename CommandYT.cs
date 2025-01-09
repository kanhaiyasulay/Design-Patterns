// watch a youtube video of "Christopher Okhravi" to understand this example code

using System;
namespace CommandPatternExample
{
    // Command interface
    interface ICommand
    {
        void Execute();
        void Unexecute();
    }

    // Receiver: The Light
    class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is OFF.");
        }
    }

    // Concrete Command: Turn On Light
    class TurnOnLightCommand : ICommand
    {
        private Light _light;

        public TurnOnLightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

        public void Unexecute()
        {
            _light.TurnOff();
        }
    }

    // Concrete Command: Turn Off Light
    class TurnOffLightCommand : ICommand
    {
        private Light _light;

        public TurnOffLightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Unexecute()
        {
            _light.TurnOn();
        }
    }

    // Invoker: Remote Control
    class RemoteControl
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            _command.Execute();
        }

        public void PressUndo()
        {
            _command.Unexecute();
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            // Receiver
            Light light = new Light();

            // Commands
//constructor of TurnOnLightCommand is parametrised therefore obj should also be parametrised
            ICommand turnOn = new TurnOnLightCommand(light);
            ICommand turnOff = new TurnOffLightCommand(light);

            // Invoker
            RemoteControl remote = new RemoteControl();

            // Turn on the light
            remote.SetCommand(turnOn);
            remote.PressButton();

            // Turn off the light
            remote.SetCommand(turnOff);
            remote.PressButton();

            // Unexecute the last action
            remote.PressUndo();
        }
    }
}


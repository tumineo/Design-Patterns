using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public interface  ICommand
    {
        void Execute();
    }

    public class Light
    {
        public void On() => Console.WriteLine("Light is On");
        public void Off() => Console.WriteLine("Light is off");
    }
    public class GarageDoor
    {
        public void Up() => Console.WriteLine("Door is Open");
        public void Down() => Console.WriteLine("Door is closed");
    }

    public class  SimpleRemoteControl
    {
        private ICommand slot = null;

        public void ButtonWasPressed()
        {
            slot?.Execute();
        }

        public void SetCommand(ICommand command)
        {
            slot = command;
        }

    }

    public class LightOnCommand : ICommand
    {
        private Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.On();
            light.Off();
        }
    }

    public class GarageDoorCommand : ICommand
    {
        private GarageDoor garageDoor;

        public GarageDoorCommand( GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.Up();
            garageDoor.Down();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var remote = new SimpleRemoteControl();

            var light = new Light();
            remote.SetCommand(new LightOnCommand(light));
            remote.ButtonWasPressed();

            var door = new GarageDoorCommand();
        }
    }
}

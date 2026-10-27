# C# Design Patterns

A small C# project created to practice and demonstrate common software design patterns.

The project contains simple implementations of design patterns studied during Software Engineering, using practical examples to understand how each pattern works and how the different components interact.

##  Design Patterns

The project includes examples of patterns such as:

- **Command Pattern**
- **Singleton Pattern**
- **Factory Pattern**
- **Strategy Pattern**
- **Observer Pattern**
- **Decorator Pattern**
- **Façade Pattern**
- **Template Method Pattern**

> More patterns can be added as the project develops.

---

##  Technologies Used

- **C#**
- **.NET**
- Object-Oriented Programming (OOP)
- Design Patterns
- Visual Studio

---

##  Purpose of the Project

The purpose of this project is to develop a practical understanding of software design patterns and how they can be used to create flexible, maintainable, and reusable code.

Rather than implementing complex applications, the project uses small examples to focus on the structure and purpose of each design pattern.

---

# Command Pattern

The current implementation demonstrates the **Command Design Pattern**.

The Command Pattern encapsulates a request as an object. This allows the request to be passed around, stored, and executed without the object making the request needing to know how the operation is performed.

### Components in this implementation

#### `ICommand`

Defines the common interface for commands.

```csharp
public interface ICommand
{
    void Execute();
}
```

Every command implements the `Execute()` method.

#### `Light`

Represents the receiver that performs the actual operation.

```csharp
public class Light
{
    public void On() => Console.WriteLine("Light is On");
    public void Off() => Console.WriteLine("Light is off");
}
```

#### `GarageDoor`

Another receiver that provides operations for opening and closing the garage door.

#### `SimpleRemoteControl`

Acts as the invoker. It stores a command and executes it when the button is pressed.

```csharp
public void ButtonWasPressed()
{
    slot?.Execute();
}
```

#### `LightOnCommand`

A concrete command that connects the remote control to the `Light` receiver.

```csharp
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
```

#### `GarageDoorCommand`

A concrete command responsible for controlling the `GarageDoor`.

---

##  Command Pattern Structure

The relationship between the classes can be simplified as:

```text
                SimpleRemoteControl
                       │
                       │ stores
                       ▼
                    ICommand
                       │
             ┌─────────┴─────────┐
             ▼                   ▼
     LightOnCommand       GarageDoorCommand
             │                   │
             ▼                   ▼
          Light             GarageDoor
```

The remote control does not need to know how the light or garage door works. It only knows that it has a command that can be executed.

---

##  Example Usage

The current program creates a remote control, creates a light, assigns a `LightOnCommand` to the remote, and then presses the remote button.

```csharp
var remote = new SimpleRemoteControl();

var light = new Light();

remote.SetCommand(new LightOnCommand(light));

remote.ButtonWasPressed();
```

### Expected Output

```text
Light is On
Light is off
```

---

## Learning Outcomes

Through this project, I practiced:

- Object-oriented programming
- Interfaces and abstraction
- Encapsulation
- Composition
- Loose coupling
- Implementing software design patterns
- Understanding the roles of **Command**, **Invoker**, **Receiver**, and **Concrete Command**
- Applying design patterns using C#

---

## Future Improvements

Possible improvements to the project include:

- Adding the remaining design patterns as separate examples
- Adding unit tests
- Improving the command implementation
- Adding undo functionality to demonstrate a more complete Command Pattern
- Creating a more structured project with separate folders for each pattern
- Adding UML diagrams for each design pattern

---

## Author

**Tumelo Neo Mofokeng**

IT Student | Software Developer & Engineer |  Cybersecurity & Cloud Computing Enthusiast

This project was created as part of my practical learning and coursework in software engineering and design patterns.

using AutoDrivingCarSimulation.Command;
using AutoDrivingCarSimulation.Interface;
using AutoDrivingCarSimulation.Enum;

namespace AutoDrivingCarSimulation.Services;

public class Car : ICar
{
    public int X { get; set; }
    public int Y { get; set; }
    public Direction FacingDirection { get; set; }

    private readonly Dictionary<char, ICommand> _commands;

    public Car(int x, int y, Direction direction)
    {
        X = x;
        Y = y;
        FacingDirection = direction;

        _commands = new Dictionary<char, ICommand>
        {
            { 'F', new MoveCommand() },
            { 'L', new TurnLeftCommand() },
            { 'R', new TurnRightCommand() }
        };
    }

    public void ExecuteCommand(char command)
    {
        if (_commands.TryGetValue(command, out var cmd))
        {
            cmd.Execute(this);
        }
    }

    public void Move()
    {
        switch (FacingDirection)
        {
            case Direction.N:
                Y++;
                break;
            case Direction.E:
                X++;
                break;
            case Direction.S:
                Y--;
                break;
            case Direction.W:
                X--;
                break;
        }
    }

    public void TurnLeft()
    {
        FacingDirection = (Direction)(((int)FacingDirection + 3) % 4);
    }

    public void TurnRight()
    {
        FacingDirection = (Direction)(((int)FacingDirection + 1) % 4);
    }
}
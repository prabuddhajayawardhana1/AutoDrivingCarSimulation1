using AutoDrivingCarSimulation.Interface;

namespace AutoDrivingCarSimulation.Command;

public class MoveCommand : ICommand
{
    public void Execute(ICar car)
    {
        car.Move();
    }
}

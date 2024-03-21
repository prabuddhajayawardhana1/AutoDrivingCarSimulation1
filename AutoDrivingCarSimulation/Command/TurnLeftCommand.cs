using AutoDrivingCarSimulation.Interface;

namespace AutoDrivingCarSimulation.Command;

public class TurnLeftCommand : ICommand
{
    public void Execute(ICar car)
    {
        car.TurnLeft();
    }
}
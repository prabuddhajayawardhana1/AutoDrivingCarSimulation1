using AutoDrivingCarSimulation.Interface;

namespace AutoDrivingCarSimulation.Command;

public class TurnRightCommand : ICommand
{
    public void Execute(ICar car)
    {
        car.TurnRight();
    }
}
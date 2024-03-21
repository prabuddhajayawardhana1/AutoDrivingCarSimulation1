namespace AutoDrivingCarSimulation.Interface;

public interface ICommand
{
    void Execute(ICar car);
}
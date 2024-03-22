using AutoDrivingCarSimulation.Enum;

namespace AutoDrivingCarSimulation.Interface;

public interface IAutoDrivingCarSimulator
{
    (int, int, Direction) SimulateCar(int width, int height, int x, int y, Direction direction, string commands);
}
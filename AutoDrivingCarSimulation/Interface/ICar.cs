using AutoDrivingCarSimulation.Enum;

namespace AutoDrivingCarSimulation.Interface;
public interface ICar
{
    int X { get; set; }
    int Y { get; set; }
    Direction FacingDirection { get; set; }

    void Move();
    void TurnLeft();
    void TurnRight();
}
using AutoDrivingCarSimulation.Enum;
using AutoDrivingCarSimulation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation.Interface;

public interface IAutoDrivingCarCollision
{
    string CheckCollision(int width, int height, Dictionary<string, (int, int, Direction, string)> cars);
}

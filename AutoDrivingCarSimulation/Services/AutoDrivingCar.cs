using AutoDrivingCarSimulation.Command;
using AutoDrivingCarSimulation.Interface;
using AutoDrivingCarSimulation.Enum;
using System.Formats.Tar;

namespace AutoDrivingCarSimulation.Services;

public class AutoDrivingCar : IAutoDrivingCarSimulator, IAutoDrivingCarCollision
{
    public (int, int, Direction) SimulateCar(int width, int height, int x, int y, Direction direction, string commands)
    {
        var car = new Car(x, y, direction);

        foreach (var command in commands)
        {
            var newCar = new Car(car.X, car.Y, car.FacingDirection);
            newCar.ExecuteCommand(command);

            if (newCar.X < 0 || newCar.X >= width || newCar.Y < 0 || newCar.Y >= height)
                continue; 

            car = newCar;
        }

        return (car.X, car.Y, car.FacingDirection);
    }

    public string CheckCollision(int width, int height, Dictionary<string, (int, int, Direction, string)> cars)
    {
        var positions = new Dictionary<string, List<(int, int)>>();
        foreach (var car in cars)
        {
            var (carX, carY, carDirection, commands) = car.Value;
            var carPositions = new List<(int, int)>();
            positions.Add(car.Key, carPositions);
            for (var i = 0; i < commands.Length; i++)
            {
                if (commands[i] == 'F')
                {
                    switch (carDirection)
                    {
                        case Direction.N:
                            carY++;
                            break;
                        case Direction.E:
                            carX++;
                            break;
                        case Direction.S:
                            carY--;
                            break;
                        case Direction.W:
                            carX--;
                            break;
                    }
                    if (carX < 0 || carX >= width || carY < 0 || carY >= height)
                        break;
                }
                else if (commands[i] == 'L')
                {
                    carDirection = (Direction)(((int)carDirection + 3) % 4);
                }
                else if (commands[i] == 'R')
                {
                    carDirection = (Direction)(((int)carDirection + 1) % 4);
                }
                carPositions.Add((carX, carY));
            }
        }

        for (var i = 0; i < positions["A"].Count; i++)
        {
            if (positions["A"][i] == positions["B"][i])
                return $"{positions["A"][i].Item1} {positions["A"][i].Item2} {i + 1}";
        }
        return "no collision";
    }
}


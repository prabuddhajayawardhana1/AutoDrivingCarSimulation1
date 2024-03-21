
using AutoDrivingCarSimulation.Persistence;
using AutoDrivingCarSimulation.Services;

// Part 1
int width = 10;
int height = 10;
int x = 1;
int y = 2;
Direction direction = Direction.N;
string commands = "FFRFFFRRLF";

var result = new AutoDrivingCar().SimulateCar(width, height, x, y, direction, commands);
Console.WriteLine($"Final position: {result.Item1} {result.Item2} {result.Item3}");

// Part 2
var cars2 = new Dictionary<string, (int, int, Direction, string)>
            {
                { "A", (1, 2, Direction.N, "FFRFFFFRRL") },
                { "B", (7, 8, Direction.W, "FFLFFFFFFF") }
            };

var resultPart2 = new AutoDrivingCar().CheckCollision(width, height, cars2);
Console.WriteLine($"Final position: {resultPart2}");

// Part 3
var cars3 = new Dictionary<string, (int, int, Direction, string)>
            {
                { "A", (1, 2, Direction.N, "FFRFFFFRRL") },
                { "B", (3, 7, Direction.W, "FFLFFFFFFF") }
            };

var resultPart3 = new AutoDrivingCar().CheckCollision(width, height, cars3);
Console.WriteLine($"Final position: {resultPart3}");

Console.ReadLine();

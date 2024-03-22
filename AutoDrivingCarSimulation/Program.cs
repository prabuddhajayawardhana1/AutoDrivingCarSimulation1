
using AutoDrivingCarSimulation.Enum;
using AutoDrivingCarSimulation.Services;

// Part 1

/*
 * int width = 10;
 * int height = 10;
 * int x = 1;
 * int y = 2;
 * Direction direction = Direction.N;
 * string commands = "FFRFFFRRLF";
 */

int width, height, x, y;
Direction direction;
string commands;

Console.WriteLine("Enter Width:");
while (!int.TryParse(Console.ReadLine(), out width) || width <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer for Width:");
}

Console.WriteLine("Enter Height:");
while (!int.TryParse(Console.ReadLine(), out height) || height <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer for Height:");
}

Console.WriteLine("Enter x:");
while (!int.TryParse(Console.ReadLine(), out x) || x < 0 || x >= width)
{
    Console.WriteLine($"Invalid input. Please enter an integer between 0 and {width - 1} for x:");
}

Console.WriteLine("Enter y:");
while (!int.TryParse(Console.ReadLine(), out y) || y < 0 || y >= height)
{
    Console.WriteLine($"Invalid input. Please enter an integer between 0 and {height - 1} for y:");
}

Console.WriteLine("Enter Direction (N/S/E/W):");
while (!Enum.TryParse(Console.ReadLine(), out direction) || !Enum.IsDefined(typeof(Direction), direction))
{
    Console.WriteLine("Invalid input. Please enter a valid direction (N/S/E/W):");
}

Console.WriteLine("Enter Commands (F: Forward, R: Right, L: Left):");
commands = Console.ReadLine();

var result = new AutoDrivingCar().SimulateCar(width, height, x, y, direction, commands);
Console.WriteLine($"Final position: {result.Item1} {result.Item2} {result.Item3}");


/*
 * int width = 10;
 * int height = 10;
 * var cars = new Dictionary<string, (int, int, Direction, string)>
 * {
 *     { "A", (1, 2, Direction.N, "FFRFFFFRRL") },
 *     { "B", (7, 8, Direction.W, "FFLFFFFFFF") }
 * };
 */

// Part 2
int carCountPart2;
Console.WriteLine("Enter the number of cars for Part 2:");
while (!int.TryParse(Console.ReadLine(), out carCountPart2) || carCountPart2 <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer for the number of cars:");
}

var cars2 = new Dictionary<string, (int, int, Direction, string)>();

for (int i = 0; i < carCountPart2; i++)
{
    Console.WriteLine($"Enter Car {i + 1} details (name, x, y, direction (N/S/E/W), commands):");
    string[] carDetails = Console.ReadLine().Split(' ');
    if (carDetails.Length != 5)
    {
        Console.WriteLine("Invalid input format. Please enter the details in the correct format.");
        i--; // Decrement i to repeat the current iteration
        continue;
    }

    string name = carDetails[0];
    int x1, y1;
    Direction direction1;
    string commands1;

    if (!int.TryParse(carDetails[1], out x1) || !int.TryParse(carDetails[2], out y1) ||
        x1 < 0 || x1 >= width || y1 < 0 || y1 >= height)
    {
        Console.WriteLine($"Invalid input for x or y. Please enter integers between 0 and {width - 1} for x and 0 and {height - 1} for y.");
        i--; // Decrement i to repeat the current iteration
        continue;
    }

    if (!Enum.TryParse(carDetails[3], out direction1) || !Enum.IsDefined(typeof(Direction), direction1))
    {
        Console.WriteLine("Invalid input for direction. Please enter a valid direction (N/S/E/W).");
        i--; // Decrement i to repeat the current iteration
        continue;
    }

    commands1 = carDetails[4];
    cars2.Add(name, (x1, y1, direction1, commands1));
}

var resultPart2 = new AutoDrivingCar().CheckCollision(width, height, cars2);
Console.WriteLine($"Final position for Part 2: {resultPart2}");

/*
 * int width = 10;
 * int height = 10;
 * var cars = new Dictionary<string, (int, int, Direction, string)>
 * {
 *      { "A", (1, 2, Direction.N, "FFRFFFFRRL") },
 *      { "B", (3, 7, Direction.W, "FFLFFFFFFF") }
 * };
 */

// Part 3
int carCountPart3;
Console.WriteLine("Enter the number of cars for Part 3:");
while (!int.TryParse(Console.ReadLine(), out carCountPart3) || carCountPart3 <= 0)
{
    Console.WriteLine("Invalid input. Please enter a positive integer for the number of cars:");
}

var cars3 = new Dictionary<string, (int, int, Direction, string)>();

for (int i = 0; i < carCountPart3; i++)
{
    Console.WriteLine($"Enter Car {i + 1} details (name, x, y, direction (N/S/E/W), commands):");
    string[] carDetails = Console.ReadLine().Split(' ');
    if (carDetails.Length != 5)
    {
        Console.WriteLine("Invalid input format. Please enter the details in the correct format.");
        i--; // Decrement i to repeat the current iteration
        continue;
    }

    string name = carDetails[0];
    int x2, y2;
    Direction direction2;
    string commands2;

    if (!int.TryParse(carDetails[1], out x2) || !int.TryParse(carDetails[2], out y2) ||
        x2 < 0 || x2 >= width || y2 < 0 || y2 >= height)
    {
        Console.WriteLine($"Invalid input for x or y. Please enter integers between 0 and {width - 1} for x and 0 and {height - 1} for y.");
        i--; // Decrement i to repeat the current iteration
        continue;
    }

    if (!Enum.TryParse(carDetails[3], out direction2) || !Enum.IsDefined(typeof(Direction), direction2))
    {
        Console.WriteLine("Invalid input for direction. Please enter a valid direction (N/S/E/W).");
        i--; // Decrement i to repeat the current iteration
        continue;
    }

    commands2 = carDetails[4];
    cars3.Add(name, (x2, y2, direction2, commands2));
}

var resultPart3 = new AutoDrivingCar().CheckCollision(width, height, cars3);
Console.WriteLine($"Final position for Part 3: {resultPart3}");

Console.ReadLine();
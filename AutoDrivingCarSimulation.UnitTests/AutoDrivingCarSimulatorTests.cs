using AutoDrivingCarSimulation.Interface;
using AutoDrivingCarSimulation.Enum;
using AutoDrivingCarSimulation.Services;

namespace AutoDrivingCarSimulation.UnitTests
{
    public class AutoDrivingCarSimulatorTests
    {
        private readonly AutoDrivingCar _simulatorMock;
        private readonly AutoDrivingCar _collisionMock;

        public AutoDrivingCarSimulatorTests()
        {
            _simulatorMock = new AutoDrivingCar();
            _collisionMock = new AutoDrivingCar();
        }

        [Fact]
        public void SimulateCar_ShouldReturnFinalPositionAndDirection()
        {
            // Arrange
            int width = 10;
            int height = 10;
            int x = 1;
            int y = 2;
            Direction direction = Direction.N;
            string commands = "FFRFFFRRLF";

            // Act
            var result = _simulatorMock.SimulateCar(width, height, x, y, direction, commands);

            // Assert
            Assert.Equal(4, result.Item1);
            Assert.Equal(3, result.Item2);
            Assert.Equal(Direction.S, result.Item3);
        }

        [Fact]
        public void CheckCollision_ShouldReturnCollisionPoint()
        {
            // Arrange
            int width = 10;
            int height = 10;
            var cars = new Dictionary<string, (int, int, Direction, string)>
            {
                { "A", (1, 2, Direction.N, "FFRFFFFRRL") },
                { "B", (7, 8, Direction.W, "FFLFFFFFFF") }
            };

            // Act
            var result = _collisionMock.CheckCollision(width, height, cars);

            // Assert
            Assert.Equal("5 4 7", result);
        }

        [Fact]
        public void CheckCollision_ShouldReturnNoCollision()
        {
            // Arrange
            int width = 10;
            int height = 10;
            var cars = new Dictionary<string, (int, int, Direction, string)>
            {
                { "A", (1, 2, Direction.N, "FFRFFFFRRL") },
                { "B", (3, 7, Direction.W, "FFLFFFFFFF") }
            };

            // Act
            var result = _collisionMock.CheckCollision(width, height, cars);

            // Assert
            Assert.Equal("no collision", result);
        }
    }
}
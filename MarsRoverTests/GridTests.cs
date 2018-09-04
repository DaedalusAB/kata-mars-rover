using MarsRover.Positioning;
using Xunit;

namespace MarsRoverTests
{
    public class GridTests
    {
        [Fact]
        public void AddObstacleToGrid()
        {
            var grid = new Grid(2,2);
            var obstacleCoordinates = new Coordinates(1, 0);
            grid.AddObstacle(obstacleCoordinates);

            Assert.True(grid.HasObstacle(obstacleCoordinates));
        }
    }
}

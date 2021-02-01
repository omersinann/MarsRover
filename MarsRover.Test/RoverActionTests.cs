using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class RoverActionTests
    {
        [Fact]
        public void RoverTurnLeftPositionShould()
        {
            var rover = new Rover { Direction = Direction.East,  Position = new Position { X = 1, Y = 1 } };
            rover.TurnLeft();
            Assert.Equal<Direction>(Direction.North, rover.Direction);
        }

        [Fact]
        public void RoverTurnRightPositionShould()
        {
            var rover = new Rover { Direction = Direction.East,  Position = new Position { X = 1, Y = 1 } };
            rover.TurnRight();
            Assert.Equal<Direction>(Direction.South, rover.Direction);
        }


        [Fact]
        public void RoverMoveShould()
        {
            var expectedResult = new Position { X = 0, Y = 1 };
            var rover = new Rover { Direction = Direction.North, Position = new Position { X = 0, Y = 0 } };

            rover.Move();

            Assert.Equal(expectedResult.X, rover.Position.X);
            Assert.Equal(expectedResult.Y, rover.Position.Y);
        }

       
    }
}

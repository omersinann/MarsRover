using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover : IRover
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public string[] Route { get; set; }


        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
            }
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    Position.Y = Position.Y + 1;
                    break;
                case Direction.West:
                    Position.X = Position.X - 1;
                    break;
                case Direction.South:
                    Position.Y = Position.Y - 1;
                    break;
                case Direction.East:
                    Position.X = Position.X + 1;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau : IPlateau
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public List<Rover> Rovers;

        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
            Rovers = new List<Rover>();
        }

        public void AddRover(int x, int y, Direction direction, string[] route)
        {
            if (x < 0 || x > Width || y < 0 || y > Height)
                throw new InvalidOperationException("Out of plateau boundaries  !");

            foreach (var rover in Rovers)
            {
                if (rover.Position.X == x && rover.Position.Y == y)
                    throw new InvalidOperationException("Error adding rover !");
            }

            Rovers.Add(new Rover { Position = new Position { X = x, Y = y }, Direction = direction, Route = route });
        }

        public void ActionValidation(Rover item)
        {
            if (item.Position.X < 0 || item.Position.X > Width || item.Position.Y < 0 || item.Position.Y > Height)
                throw new InvalidOperationException("There was a problem while the rover was moving !");

            var otherRovers = Rovers.Where(x => x != item).ToList();
            foreach (var rover in otherRovers)
            {
                if (rover.Position.X == item.Position.X && rover.Position.Y == item.Position.Y)
                    throw new InvalidOperationException("There was a problem while the rover was moving !");
            }
        }
    }
}

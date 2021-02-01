using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
   public class PlateauActionTests
    {
        [Fact]
        public void AddRoverShould()
        {
            var plateau = new Plateau(5, 5);
            plateau.AddRover(1, 1, Direction.North, null);

            Assert.True(plateau.Rovers.Count == 1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    interface IPlateau
    {
        void AddRover(int x, int y, Direction direction, string[] route);
        void ActionValidation(Rover item);
    }
}

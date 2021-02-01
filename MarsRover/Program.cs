using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Mars plateau sizes (x y) : ");
                var plateauArray = Console.ReadLine().Split(' ');
                var plateau = new Plateau(Convert.ToInt32(plateauArray[0]), Convert.ToInt32(plateauArray[1]));

                List<string[]> roversInput = new List<string[]>();
                List<string[]> roversRouteInput = new List<string[]>();

                Input:
                Console.WriteLine("If you want to add a new mars rover, enter (x y) values. Press the 'Enter' key without entering a value to continue running the application. ");
                var inputRover = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(inputRover))
                {
                    var inputRoverArray = inputRover.Split(' ');
                    roversInput.Add(inputRoverArray);

                    Console.WriteLine("This rover route : ");
                    var roverRoute = Console.ReadLine();
                    var roverRouteArray = roverRoute.ToCharArray().Select(c => c.ToString()).ToArray();
                    roversRouteInput.Add(roverRouteArray);
                    goto Input;
                }

                for (int i = 0; i < roversInput.Count; i++)
                {
                    var newRover = roversInput[i];
                    plateau.AddRover(Convert.ToInt32(newRover[0]), Convert.ToInt32(newRover[1]), InputDirection(newRover[2].ToString().ToUpper()), roversRouteInput[i]);
                }

                foreach (var item in plateau.Rovers)
                {
                    foreach (var itemRoute in item.Route)
                    {
                        switch (itemRoute.ToUpper())
                        {
                            case "L":
                                item.TurnLeft();
                                break;
                            case "R":
                                item.TurnRight();
                                break;
                            case "M":
                                item.Move();
                                plateau.ActionValidation(item);
                                break;
                            default:
                                throw new InvalidOperationException("Invalid command !");

                        }
                    }
                }

                foreach (var item in plateau.Rovers)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", item.Position.X.ToString(), item.Position.Y.ToString(), item.Direction.ToString()));
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }


        }

        private static Direction InputDirection(string inputDirection)
        {
            Direction direction;
            switch (inputDirection)
            {
                case "N":
                    direction = Direction.North;
                    break;
                case "E":
                    direction = Direction.East;
                    break;
                case "w":
                    direction = Direction.West;
                    break;
                case "S":
                    direction = Direction.South;
                    break;
                default:
                    throw new InvalidOperationException("Invalid direction entry ! ");
            }
            return direction;
        }

    }
}

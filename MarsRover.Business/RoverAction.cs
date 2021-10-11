using MarsRover.Business.RoverActions;
using MarsRover.Core;
using MarsRover.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public static class RoverAction
    {
        public static IRoverDirection RoverDirection(IRoverPosition roverPosition)
        {
            IRoverDirection roverDirection = null;
            switch (roverPosition.Direction)
            {
                case Direction.N:
                    {
                        roverDirection = new NorthDirection(roverPosition);
                        break;
                    }
                case Direction.W:
                    {
                        roverDirection = new WestDirection(roverPosition);
                        break;
                    }
                case Direction.E:
                    {
                        roverDirection = new EastDirection(roverPosition);
                        break;
                    }
                case Direction.S:
                    {
                        roverDirection = new SouthDirection(roverPosition);
                        break;
                    }
                case Direction.EMPTY:
                    break;
                default:
                    break;
            }
            return roverDirection;
        }
    }
}

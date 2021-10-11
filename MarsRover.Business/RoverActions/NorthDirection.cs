using MarsRover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.RoverActions
{
    public class NorthDirection : IRoverDirection
    {
        private readonly IRoverPosition _roverPosition;
        public NorthDirection(IRoverPosition roverPosition)
        {
            _roverPosition = roverPosition;
        }
        public IRoverPosition MoveForward()
        {
            _roverPosition.Y += 1;
            return _roverPosition;
        }

        public IRoverPosition TurnLeft()
        {
            _roverPosition.Direction = Core.Utilities.Direction.W;
            return _roverPosition;
        }

        public IRoverPosition TurnRight()
        {
            _roverPosition.Direction = Core.Utilities.Direction.E;
            return _roverPosition;
        }
    }
}

using MarsRover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.RoverActions
{
    public class EastDirection : IRoverDirection
    {
        private readonly IRoverPosition _roverPosition;
        public EastDirection(IRoverPosition roverPosition)
        {
            _roverPosition = roverPosition;
        }
        public IRoverPosition MoveForward()
        {
            _roverPosition.X += 1;
            return _roverPosition;
        }

        public IRoverPosition TurnLeft()
        {
            _roverPosition.Direction = Core.Utilities.Direction.N;
            return _roverPosition;
        }

        public IRoverPosition TurnRight()
        {
            _roverPosition.Direction = Core.Utilities.Direction.S;
            return _roverPosition;
        }
    }
}

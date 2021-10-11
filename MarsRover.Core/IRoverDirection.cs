using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public interface IRoverDirection
    {
        IRoverPosition MoveForward();
        IRoverPosition TurnLeft();
        IRoverPosition TurnRight();
    }
}

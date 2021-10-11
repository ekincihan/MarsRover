using MarsRover.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public interface IRoverPosition
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }
        void Create(string positionInput);
    }
}

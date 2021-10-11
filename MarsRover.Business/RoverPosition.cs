using MarsRover.Core;
using MarsRover.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public class RoverPosition : IRoverPosition
    {
        public int X { get; set; } 
        public int Y { get; set; } 
        public Direction Direction { get; set; }
        public void Create(string positionInput)
        {
            int x = 0, y = 0;
            Direction direction = Direction.EMPTY;
            if (positionInput.Trim().IndexOf(" ") > -1)
            {
                string[] positions = positionInput.Split(" ").ToArray();

                if (positions.Length == 3)
                {
                    x = int.TryParse(positions[0], out x) ? x : 0;
                    y = int.TryParse(positions[1], out y) ? y : 0;
                    direction = Enum.TryParse(positions[2], out direction) ? direction : Direction.EMPTY;
                }
            }
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }
    }
}

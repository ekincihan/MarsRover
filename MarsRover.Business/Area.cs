using MarsRover.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public class Area : IArea
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void Create(string areaInput)
        {
            int x = 0, y = 0;
            if (areaInput.Trim().IndexOf(" ") > -1)
            {
                string[] position = areaInput.Split(" ").ToArray();

                this.X = int.TryParse(position[0], out x) ? x : 0;
                this.Y = int.TryParse(position[1], out y) ? y : 0;
            }
        }
    }
}

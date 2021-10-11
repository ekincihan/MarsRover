using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public interface IArea
    {
        int X { get; set; }
        int Y { get; set; }
        void Create(string areaInput);
    }
}

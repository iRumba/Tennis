using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public struct BallState
    {
        public double Size { get; set; }
        public double Speed { get; set; }
        public double Speedup { get; set; }
        public double DirectionAngle { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
    }
}

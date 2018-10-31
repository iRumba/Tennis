using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public struct PlayerState
    {
        public bool MovingTop { get; set; }
        public bool MovingBottom { get; set; }

        /// <summary>
        /// В пикселях в секунду
        /// </summary>
        public double Speed { get; set; }

        public double RocketSize { get; set; }

        public double PositionX { get; set; }

        public double PositionY { get; set; }
    }
}

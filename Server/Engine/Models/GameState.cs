using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public struct GameState
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Map Map { get; set; }
        public BallState BallState { get; set; }
    }
}

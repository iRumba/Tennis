using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public struct Player
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public PlayerState State { get; set; }
    }
}

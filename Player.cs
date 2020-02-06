using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfScore
{
    class Player
    {
        public string Name { get; }
        public double Money { get; }
        public Player(string name, double money)
        {
            Name = name;
            Money = money;
        }
    }
}

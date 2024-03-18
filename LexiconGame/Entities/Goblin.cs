using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconGame.Entities
{
    internal class Goblin : Creature
    {
        public Goblin(Cell cell) : base(cell, "G ", 50)
        {
            Damage = 15;
            Color = ConsoleColor.DarkBlue;
        }

    }
}

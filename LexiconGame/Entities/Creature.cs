using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconGame.Entities
{
    internal class Creature : IDrawable
    {
        public Cell Cell { get; set; }
        public string Symbol { get; }
        public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;

        public Creature(Cell cell, string symbol)
        {
            Cell = cell;
            Symbol = symbol;
        }

    }
}

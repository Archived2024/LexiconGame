using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconGame.Entities
{
    internal class Creature : IDrawable
    {
        private Cell cell;
        private int health;
        public Cell Cell
        {
            get => cell;

            [MemberNotNull(nameof(cell))]
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(cell));
                cell = value;
            }
        }
        public string Symbol { get; }
        public int MaxHealth { get; }
        public int Health
        {
            get => health;
            set => health = value >= MaxHealth ? MaxHealth : value;

        }
        public bool IsDead => health <= 0;
        public int Damage { get; protected set; } = 50;
        public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;

        public Creature(Cell cell, string symbol, int maxHealth)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException($"'{nameof(symbol)}' cannot be null or whitespace.", nameof(symbol));
            }

            Cell = cell;
            Symbol = symbol;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

    }
}

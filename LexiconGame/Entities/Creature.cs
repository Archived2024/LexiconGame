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
        private ConsoleColor color;

        public string Name => GetType().Name;
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
        public ConsoleColor Color 
        {
            get => IsDead ? ConsoleColor.Gray : color; 
            protected set => color = value;
        } 

        public static Action<string> AddToLog { get; set; } = null!;

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

        internal void Attack(Creature target)
        {
            if (target.IsDead || this.IsDead) return;

            var attacker = this.Name;

            target.Health -= Damage;

            AddToLog?.Invoke($"The {attacker} attacks the {target.Name} for {this.Damage}");

            if (target.IsDead)
                AddToLog?.Invoke($"The {target.Name} is dead");
        }

    }
}

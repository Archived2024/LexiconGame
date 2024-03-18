namespace LexiconGame.Entities
{
    internal class Orc : Creature
        {
            public Orc(Cell cell) : base(cell, "0 ", 80)
            {
                Damage = 40;
                Color = ConsoleColor.DarkGreen;
            }
        }
}

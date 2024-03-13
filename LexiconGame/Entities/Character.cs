using LexiconGame.Entities;

internal class Character : Creature
{
    public Character(Cell cell) : base(cell, "H ")
    {
        Color = ConsoleColor.White;
    }
}
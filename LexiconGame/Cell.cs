internal class Cell
{
    //ToDo: Change to enum?
    public string Symbol => ".";
    public ConsoleColor Color { get; }

    public Cell()
    {
        Color = ConsoleColor.Red; 
    }


}
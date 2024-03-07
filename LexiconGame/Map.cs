internal class Map
{
    private int width;
    private int height;

    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;

        var cells = new Cell[width, height]; 
    }
}
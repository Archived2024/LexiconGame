namespace LexiconGame.Services
{
    public interface IMapService
    {
        (int width, int height) GetMap();
    }
}
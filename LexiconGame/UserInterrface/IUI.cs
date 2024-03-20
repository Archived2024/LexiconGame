
internal interface IUI
{
    void AddMessage(string message);
    void Clear();
    void Draw();
    ConsoleKey GetKey();
    void PrintLog();
    void PrintStats(string stats);
}

public class ConsoleUIMock : IUI
{
    public void AddMessage(string message)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public ConsoleKey GetKey()
    {
        return ConsoleKey.P;
    }

    public void PrintLog()
    {
        throw new NotImplementedException();
    }

    public void PrintStats(string stats)
    {
        throw new NotImplementedException();
    }

    void IUI.Draw()
    {
        throw new NotImplementedException();
    }
}
namespace GMWeb.Services;

public class CountService
{
    public int Cnt { get; private set; }

    public CountService()
    {
    }
    
    public int AddCount()
    {
        return ++Cnt;
    }
}
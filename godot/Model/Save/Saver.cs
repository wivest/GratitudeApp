namespace GratitudeApp.Model.Save;

public class Saver<T>
{
    private readonly string savePath;

    public Saver(string savePath)
    {
        this.savePath = savePath;
    }

    public T Load()
    {
        throw new System.NotImplementedException();
    }

    public void Save(T resource)
    {
        throw new System.NotImplementedException();
    }
}

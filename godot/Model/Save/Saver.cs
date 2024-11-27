using Godot;

namespace GratitudeApp.Model.Save;

public class Saver<T>
    where T : Resource
{
    private readonly string savePath;

    public Saver(string savePath)
    {
        this.savePath = savePath;
    }

    public T Load()
    {
        return ResourceLoader.Load<T>(savePath);
    }

    public void Save(T resource)
    {
        ResourceSaver.Save(resource, savePath);
    }
}

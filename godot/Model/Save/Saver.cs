using Godot;

namespace GratitudeApp.Model.Save;

public class Saver<T>
    where T : Resource, new()
{
    private readonly string savePath;

    public Saver(string savePath)
    {
        this.savePath = savePath;
    }

    public T Load()
    {
        if (!ResourceLoader.Exists(savePath))
            return new T();
        return ResourceLoader.Load<T>(savePath, cacheMode: ResourceLoader.CacheMode.Ignore);
    }

    public void Save(T resource)
    {
        ResourceSaver.Save(resource, savePath);
    }
}

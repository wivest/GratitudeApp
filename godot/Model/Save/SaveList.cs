using Godot;
using Godot.Collections;

namespace GratitudeApp.Model.Save;

partial class SaveList<[MustBeVariant] T> : Resource, ISaveFile<T>
{
    public string SavePath { get; }

    public SaveList(string savePath)
    {
        SavePath = savePath;
    }

    public Array<T> Load()
    {
        throw new System.NotImplementedException();
    }

    public void Save(Array<T> items)
    {
        throw new System.NotImplementedException();
    }
}

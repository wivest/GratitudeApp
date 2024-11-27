using Godot;
using Godot.Collections;

namespace GratitudeApp.Model.Save;

partial class SaveArray<[MustBeVariant] T> : Resource, ISaveFile<T>
{
    public string SavePath { get; }

    public Array<T> Items { get; set; }

    public SaveArray(string savePath)
    {
        SavePath = savePath;
    }

    public void Load()
    {
        throw new System.NotImplementedException();
    }

    public void Save()
    {
        throw new System.NotImplementedException();
    }
}

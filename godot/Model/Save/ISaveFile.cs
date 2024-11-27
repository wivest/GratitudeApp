using Godot;
using Godot.Collections;

namespace GratitudeApp.Model.Save;

interface ISaveFile<[MustBeVariant] T>
{
    public string SavePath { get; }

    public Array<T> Load();
    public void Save(Array<T> items);
}

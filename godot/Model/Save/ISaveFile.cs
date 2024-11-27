using Godot;
using Godot.Collections;

namespace GratitudeApp.Model.Save;

interface ISaveFile<[MustBeVariant] T>
{
    public string SavePath { get; }

    [Export]
    public Array<T> Items { get; set; }

    public void Load();
    public void Save();
}

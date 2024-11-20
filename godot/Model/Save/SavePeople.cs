using Godot;

namespace GratitudeApp.Model.Save;

partial class SavePeople : Resource, ISaveFile
{
    public string SavePath
    {
        get => "user://people.tres";
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

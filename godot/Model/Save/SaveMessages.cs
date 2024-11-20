using Godot;

namespace GratitudeApp.Model.Save;

partial class SaveMessages : Resource, ISaveFile
{
    public string SavePath
    {
        get => "user://messages.tres";
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

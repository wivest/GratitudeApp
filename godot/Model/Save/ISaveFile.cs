namespace GratitudeApp.Model.Save;

interface ISaveFile
{
    public string SavePath { get; }

    public void Load();
    public void Save();
}

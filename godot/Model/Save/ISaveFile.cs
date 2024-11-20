namespace GratitudeApp.Model.Save;

interface ISaveFile
{
    public string SavePath { get; set; }

    public void Load();
    public void Save();
}

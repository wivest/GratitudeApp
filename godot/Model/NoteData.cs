using Godot;
using Godot.Collections;

namespace GratitudeApp.Model;

public partial class NoteData : Resource
{
    [Export]
    public string Text { get; set; }

    [Export]
    public Array<Person> Tagged { get; set; }

    [Export]
    public double UnixTime { get; set; }

    [Export]
    public bool Edited { get; set; }

    public string TimeString
    {
        get => Time.GetTimeStringFromUnixTime((long)UnixTime);
    }
}

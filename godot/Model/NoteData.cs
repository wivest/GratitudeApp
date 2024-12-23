using Godot;
using Godot.Collections;

namespace GratitudeApp.Model;

public partial class NoteData : Resource
{
    [Export]
    public string Text { get; set; }

    [Export]
    public Array<PersonData> Tagged { get; set; }

    [Export]
    public long UnixTime { get; set; }

    [Export]
    public bool Edited { get; set; }

    public string TimeString
    {
        get => Time.GetTimeStringFromUnixTime(UnixTime);
    }
    public string EditedString
    {
        get => Edited ? "edited" : "not edited";
    }
}

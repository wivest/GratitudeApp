using Godot;
using Godot.Collections;

namespace GratitudeApp.Model.Save;

public partial class NoteSave : Resource
{
    [Export]
    public Array<NoteData> Notes { get; set; }
}

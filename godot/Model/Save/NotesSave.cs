using Godot;
using Godot.Collections;

namespace GratitudeApp.Model.Save;

public partial class NotesSave : Resource
{
    [Export]
    public Array<NoteData> Notes = new();
}

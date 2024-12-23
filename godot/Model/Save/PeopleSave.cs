using Godot;
using Godot.Collections;

namespace GratitudeApp.Model.Save;

public partial class PeopleSave : Resource
{
    [Export]
    public Array<PersonData> People = new();
}

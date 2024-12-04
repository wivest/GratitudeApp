using Godot;
using Godot.Collections;

namespace GratitudeApp.Model.Save;

public partial class PersonSave : Resource
{
    [Export]
    public Array<Person> People = new();
}

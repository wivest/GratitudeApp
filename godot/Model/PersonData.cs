using Godot;

namespace GratitudeApp.Model;

public partial class PersonData : Resource
{
    [Export]
    public string Name;

    [Export]
    public string Tag;
}

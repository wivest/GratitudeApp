using Godot;

namespace GratitudeApp.Model;

public partial class Person : Resource
{
    [Export]
    public string Name;

    [Export]
    public string Tag;
}

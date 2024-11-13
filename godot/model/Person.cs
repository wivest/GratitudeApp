using Godot;

namespace GratitudeApp;

[GlobalClass]
public partial class Person : Resource
{
    [Export]
    public string Name;

    [Export]
    public string Tag;
}

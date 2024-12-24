using Godot;

namespace GratitudeApp.UI.Switcher;

[GlobalClass]
public partial class StateScene : Resource
{
    [Export]
    public PackedScene Scene;

    [Export]
    public bool OnStart;
}

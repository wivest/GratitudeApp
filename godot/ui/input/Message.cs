using Godot;

namespace GratitudeApp;

public partial class Message : Resource
{
    [Export]
    public string Text { get; set; }
}

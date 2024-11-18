using Godot;

namespace GratitudeApp.Model;

public partial class Message : Resource
{
    [Export]
    public string Text { get; set; }
}

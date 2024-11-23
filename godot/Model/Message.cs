using Godot;
using Godot.Collections;

namespace GratitudeApp.Model;

public partial class Message : Resource
{
    [Export]
    public string Text { get; set; }

    [Export]
    public Array<Person> Tagged { get; set; }

    [Export]
    public float Time { get; set; }

    [Export]
    public bool Edited { get; set; }
}

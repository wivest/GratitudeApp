using System;
using Godot;

namespace GratitudeApp.UI.Switcher;

public partial class StateButton : Button
{
    public event Action<Control> StatePressed;
    public PackedScene State { get; set; }

    public override void _Ready()
    {
        Pressed += () => StatePressed?.Invoke(State.Instantiate<Control>());
    }
}

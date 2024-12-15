using System;
using Godot;

namespace GratitudeApp.UI.Switcher;

public partial class StateButton : Button
{
    public event Action<Node> StatePressed;

    public override void _Ready()
    {
        Pressed += () => StatePressed?.Invoke(new Node());
    }
}

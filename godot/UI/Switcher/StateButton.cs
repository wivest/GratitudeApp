using System;
using Godot;

namespace GratitudeApp.UI.Switcher;

public partial class StateButton : Button
{
    public event Action<Control> StatePressed;
    public PackedScene State { get; set; }

    public override void _Ready()
    {
        Pressed += OnPressed;
    }

    private void OnPressed()
    {
        Control node = State.Instantiate<Control>();
        node.SizeFlagsVertical = SizeFlags.ExpandFill;
        StatePressed?.Invoke(node);
    }
}

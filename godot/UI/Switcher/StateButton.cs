using System;
using Godot;

namespace GratitudeApp.UI.Switcher;

public partial class StateButton : Button
{
    public event Action<Control> StateChanged;
    public StateScene State { get; set; }

    public override void _Ready()
    {
        Pressed += OnPressed;
        if (State.OnStart)
            OnPressed();
    }

    private void OnPressed()
    {
        Control node = State.Scene.Instantiate<Control>();
        node.SizeFlagsVertical = SizeFlags.ExpandFill;
        StateChanged?.Invoke(node);
    }
}

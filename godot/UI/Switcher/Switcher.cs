using Godot;
using Godot.Collections;

namespace GratitudeApp.UI.Switcher;

public partial class Switcher : VBoxContainer
{
    [Export]
    private Array<StateScene> scenes;

    private Control stateNode;
    private HBoxContainer buttons;

    public override void _Ready()
    {
        stateNode = GetNode<Control>("State");
        buttons = GetNode<HBoxContainer>("Buttons");

        foreach (StateScene scene in scenes)
        {
            Control node = scene.Scene.Instantiate<Control>();
            var button = new StateButton
            {
                Text = node.Name,
                State = scene,
                SizeFlagsHorizontal = SizeFlags.ExpandFill
            };
            button.StateChanged += OnStateChanged;
            buttons.AddChild(button);
        }
    }

    private void OnStateChanged(Control state)
    {
        foreach (Node child in stateNode.GetChildren())
            child.QueueFree();
        stateNode.ReplaceBy(state);
        stateNode = state;
    }
}

using Godot;
using Godot.Collections;

namespace GratitudeApp.UI.Switcher;

public partial class Switcher : VBoxContainer
{
    [Export]
    private Array<Control> States;

    private Control stateNode;
    private HBoxContainer buttons;

    public override void _Ready()
    {
        stateNode = GetNode<Control>("State");
        buttons = GetNode<HBoxContainer>("Buttons");

        foreach (Control state in States)
        {
            var button = new StateButton { Text = state.Name, State = state };
            button.StatePressed += (Control node) => stateNode = node;
            buttons.AddChild(button);
        }
    }
}

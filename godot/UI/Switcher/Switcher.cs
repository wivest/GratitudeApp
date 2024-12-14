using Godot;
using Godot.Collections;

namespace GratitudeApp.UI.Switcher;

public partial class Switcher : VBoxContainer
{
    [Export]
    private Array<Node> States;

    private Node stateNode;
    private HBoxContainer buttons;

    public override void _Ready()
    {
        stateNode = GetNode<Node>("State");
        buttons = GetNode<HBoxContainer>("Buttons");

        foreach (Node state in States)
        {
            var button = new Button { Text = state.Name };
            buttons.AddChild(button);
        }
    }
}

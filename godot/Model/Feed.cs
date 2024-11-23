using Godot;

namespace GratitudeApp.Model;

public partial class Feed : ScrollContainer
{
    [Export]
    private InputLine inputLine;

    private VBoxContainer container;

    public override void _Ready()
    {
        container = GetNode<VBoxContainer>("Container");

        inputLine.MessageSaved += OnNoteSaved;
    }

    private void OnNoteSaved(string note)
    {
        GD.Print(note);
    }
}

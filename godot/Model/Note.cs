using Godot;

namespace GratitudeApp.Model;

public partial class Note : VBoxContainer
{
    public readonly NoteData NoteResource;

    private HBoxContainer container = new();

    private Label text;
    private Label date;
    private Label edited;

    public Note(NoteData note)
    {
        NoteResource = note;

        text = new Label { Text = note.Text };
        date = new Label { Text = note.TimeString };
        edited = new Label { Text = note.EditedString };

        container.AddChild(edited);
        container.AddChild(date);
        AddChild(text);
        AddChild(container);
    }
}

using Godot;

namespace GratitudeApp.Model;

public partial class NoteWidget : VBoxContainer
{
    private Label text;
    private Label date;
    private Label edited;

    public NoteWidget(Message note)
    {
        text = new Label { Text = note.Text };
        date = new Label { Text = note.Time.ToString() };
        edited = new Label { Text = note.Edited.ToString() };

        AddChild(text);
        AddChild(date);
        AddChild(edited);
    }
}

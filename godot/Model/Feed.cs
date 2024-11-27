using System.Collections.Generic;
using Godot;
using Godot.Collections;
using GratitudeApp.Model.Save;

namespace GratitudeApp.Model;

public partial class Feed : ScrollContainer
{
    [Export]
    private InputLine inputLine;

    private VBoxContainer container;

    private SaveList<NoteData> saver = new("user://people.tres");

    public override void _Ready()
    {
        container = GetNode<VBoxContainer>("Container");

        inputLine.MessageSaved += OnNoteSaved;
    }

    public void SaveNotes()
    {
        var notes = new List<NoteData>();
        foreach (Node child in container.GetChildren())
        {
            Note note = (Note)child;
            notes.Add(note.NoteResource);
        }
        saver.Save(new Array<NoteData>(notes));
    }

    private void OnNoteSaved(string text)
    {
        var note = new NoteData { Text = text, UnixTime = Time.GetUnixTimeFromSystem() };
        container.AddChild(new Note(note));
    }
}

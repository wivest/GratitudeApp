using System.Collections.Generic;
using Godot;
using Godot.Collections;
using GratitudeApp.Model.Save;

namespace GratitudeApp.Model;

public partial class Feed : ScrollContainer
{
    [Export]
    private InputLine inputLine;

    [Export]
    private Button clearButton;

    private VBoxContainer container;

    private readonly Saver<NoteSave> saver = new("user://notes.tres");

    public override void _Ready()
    {
        container = GetNode<VBoxContainer>("Container");
        LoadNotes();

        inputLine.MessageSaved += OnNoteSaved;
        clearButton.Pressed += ClearNotes;
    }

    private void LoadNotes()
    {
        NoteSave notes = saver.Load();
        foreach (NoteData noteData in notes.Notes)
            container.AddChild(new Note(noteData));
    }

    private void SaveNotes()
    {
        var notes = new List<NoteData>();
        foreach (Node child in container.GetChildren())
        {
            Note note = (Note)child;
            notes.Add(note.NoteResource);
        }

        saver.Save(new NoteSave { Notes = new Array<NoteData>(notes) });
    }

    private void ClearNotes()
    {
        foreach (Node child in container.GetChildren())
            child.QueueFree();
        SaveNotes();
    }

    private void OnNoteSaved(string text)
    {
        var note = new NoteData { Text = text, UnixTime = (long)Time.GetUnixTimeFromSystem() };
        container.AddChild(new Note(note));
        SaveNotes();
    }
}

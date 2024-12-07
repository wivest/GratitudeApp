using System;
using System.Collections.Generic;
using Godot;
using GratitudeApp.Model;

namespace GratitudeApp.UI.Notes;

public partial class InputLine : Control
{
    public static List<Person> People { get; set; } = new();

    public event Action<string> MessageSaved;
    public event Action<List<Person>> PeopleMatched;

    private LineEdit lineEdit;
    private Button saveButton;

    public override void _Ready()
    {
        lineEdit = GetNode<LineEdit>("LineEdit");
        saveButton = GetNode<Button>("Button");

        saveButton.Pressed += OnMessageSaved;
        lineEdit.TextChanged += OnTextChanged;
    }

    private void OnTextChanged(string text)
    {
        string lastWord = text.Split(' ')[^1];
        if (!lastWord.StartsWith('@'))
            return;
        string tag = lastWord.Split('@')[^1];

        var matchedPeople = new List<Person>();
        foreach (Person person in People)
        {
            if (person.Tag.StartsWith(tag))
                matchedPeople.Add(person);
        }
        PeopleMatched(matchedPeople);
    }

    private void OnMessageSaved()
    {
        string message = lineEdit.Text;
        lineEdit.Text = "";

        if (message != "")
            MessageSaved?.Invoke(message);
    }
}

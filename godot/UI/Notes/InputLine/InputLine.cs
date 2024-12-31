using System;
using System.Collections.Generic;
using Godot;
using GratitudeApp.Model;
using GratitudeApp.Model.Save;

namespace GratitudeApp.UI.Notes;

public partial class InputLine : HBoxContainer
{
    public event Action<string> MessageSaved;
    public event Action<PersonData> PersonMatched;
    public event Action InputUpdated;

    private LineEdit lineEdit;
    private Button saveButton;

    [Export]
    private Hints hints;

    private readonly Saver<PeopleSave> saver = new("user://people.tres");

    public override void _Ready()
    {
        lineEdit = GetNode<LineEdit>("LineEdit");
        saveButton = GetNode<Button>("Button");

        saveButton.Pressed += OnMessageSaved;
        lineEdit.TextChanged += (string t) => InputUpdated?.Invoke();
        lineEdit.TextChanged += OnTextChanged;
        hints.PersonChosen += OnPersonChosen;
    }

    private void OnMessageSaved()
    {
        string message = lineEdit.Text;
        lineEdit.Text = "";

        if (message != "")
            MessageSaved?.Invoke(message);
    }

    private void OnTextChanged(string text)
    {
        string lastWord = text.Split(' ')[^1];
        if (!lastWord.StartsWith('@'))
            return;
        string tag = lastWord.Split('@')[^1];

        PeopleSave save = saver.Load();
        var people = new List<PersonData>(save.People);
        foreach (PersonData person in people)
        {
            if (person.Tag.StartsWith(tag))
                PersonMatched?.Invoke(person);
        }
    }

    private void OnPersonChosen(PersonData person) { }
}

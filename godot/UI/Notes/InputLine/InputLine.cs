using System;
using System.Collections.Generic;
using Godot;
using GratitudeApp.Model;
using GratitudeApp.Model.Save;

namespace GratitudeApp.UI.Notes;

public partial class InputLine : Control
{
    public event Action<string> MessageSaved;

    private LineEdit lineEdit;
    private Button saveButton;

    private readonly Saver<PeopleSave> saver = new("user://people.tres");

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

        // TODO: suggest matchings
        PeopleSave save = saver.Load();
        var people = new List<PersonData>(save.People);
    }

    private void OnMessageSaved()
    {
        string message = lineEdit.Text;
        lineEdit.Text = "";

        if (message != "")
            MessageSaved?.Invoke(message);
    }
}

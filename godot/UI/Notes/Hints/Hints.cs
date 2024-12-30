using System;
using Godot;
using GratitudeApp.Model;

namespace GratitudeApp.UI.Notes;

public partial class Hints : VBoxContainer
{
    public event Action<Person> PersonChosen;

    [Export]
    private InputLine inputLine;

    public override void _Ready()
    {
        inputLine.PersonMatched += OnPersonMatched;
    }

    private void OnPersonMatched(PersonData person)
    {
        var hint = new Button { Text = $"{person.Name} ({person.Tag})" };
        AddChild(hint);
    }
}

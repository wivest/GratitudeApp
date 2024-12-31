using System;
using Godot;
using GratitudeApp.Model;

namespace GratitudeApp.UI.Notes;

public partial class Hints : VBoxContainer
{
    public event Action<PersonData> PersonChosen;

    [Export]
    private InputLine inputLine;

    public override void _Ready()
    {
        inputLine.InputUpdated += () =>
        {
            foreach (var child in GetChildren())
                child.QueueFree();
        };
        inputLine.PersonMatched += OnPersonMatched;
    }

    private void OnPersonMatched(PersonData person)
    {
        var hint = new HintButton { Text = $"{person.Name} ({person.Tag})", Person = person };
        AddChild(hint);
    }
}

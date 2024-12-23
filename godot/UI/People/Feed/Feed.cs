using System.Collections.Generic;
using Godot;
using Godot.Collections;
using GratitudeApp.Model;
using GratitudeApp.Model.Save;

namespace GratitudeApp.UI.People;

public partial class Feed : ScrollContainer
{
    [Export]
    private InputLine inputLine;

    private VBoxContainer container;

    private readonly Saver<PeopleSave> saver = new("user://people.tres");

    public override void _Ready()
    {
        container = GetNode<VBoxContainer>("Container");
        LoadPeople();

        inputLine.PersonSaved += OnPersonSaved;
    }

    private void LoadPeople()
    {
        PeopleSave people = saver.Load();
        foreach (PersonData person in people.People)
            container.AddChild(new Person(person));
    }

    private void SavePeople()
    {
        var people = new List<PersonData>();

        foreach (Node child in container.GetChildren())
        {
            var person = (Person)child;
            people.Add(person.PersonResource);
        }

        saver.Save(new PeopleSave { People = new Array<PersonData>(people) });
    }

    private void OnPersonSaved(PersonData person)
    {
        container.AddChild(new Person(person));
        SavePeople();
    }
}

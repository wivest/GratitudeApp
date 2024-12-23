using Godot;
using GratitudeApp.Model;
using GratitudeApp.Model.Save;

namespace GratitudeApp.UI.People;

public partial class Feed : ScrollContainer
{
    [Export]
    private InputLine inputLine;

    private VBoxContainer container;

    private readonly Saver<PersonSave> saver = new("user://people.tres");

    public override void _Ready()
    {
        container = GetNode<VBoxContainer>("Container");
        LoadPeople();
    }

    private void LoadPeople()
    {
        PersonSave people = saver.Load();
        foreach (Person person in people.People)
            container.AddChild(new PersonHint(person));
    }
}

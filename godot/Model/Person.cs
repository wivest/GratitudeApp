using Godot;

namespace GratitudeApp.Model;

public partial class Person : VBoxContainer
{
    private Label name;
    private Label tag;

    public Person(PersonData person)
    {
        name = new Label { Text = person.Name };
        tag = new Label { Text = person.Tag };

        AddChild(name);
        AddChild(tag);
    }
}

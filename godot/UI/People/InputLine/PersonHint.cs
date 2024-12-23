using Godot;
using GratitudeApp.Model;

namespace GratitudeApp;

public partial class PersonHint : Button
{
    public readonly PersonData PersonResource;

    public PersonHint(PersonData person)
    {
        PersonResource = person;
    }
}

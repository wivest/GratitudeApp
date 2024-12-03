using Godot;
using GratitudeApp.Model;

namespace GratitudeApp;

public partial class PersonHint : Button
{
    public readonly Person PersonResource;

    public PersonHint(Person person)
    {
        PersonResource = person;
    }
}

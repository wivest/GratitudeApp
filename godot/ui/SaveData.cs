using Godot;
using Godot.Collections;
using GratitudeApp.Model;

namespace GratitudeApp
{
    [GlobalClass]
    public partial class SaveData : Resource
    {
        [Export]
        public Array<Message> Messages = new();

        [Export]
        public Array<Person> People = new();
    }
}

using Godot;
using Godot.Collections;
using GratitudeApp.Model;

namespace GratitudeApp
{
    [GlobalClass]
    public partial class SaveData : Resource
    {
        [Export]
        public Array<NoteData> Messages = new();

        [Export]
        public Array<PersonData> People = new();
    }
}

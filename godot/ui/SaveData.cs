using Godot;
using GratitudeApp.Model;

namespace GratitudeApp
{
    [GlobalClass]
    public partial class SaveData : Resource
    {
        [Export]
        public Godot.Collections.Array<Message> Messages = new();
    }
}

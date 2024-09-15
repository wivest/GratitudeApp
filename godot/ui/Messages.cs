using Godot;

namespace GratitudeApp
{
    public partial class Messages : VBoxContainer
    {
        [Export]
        private InputLine inputLine;
        private VBoxContainer messages;

        public override void _Ready()
        {
            messages = GetNode<VBoxContainer>("Messages");
            inputLine.MessageSaved += OnMessageSaved;
        }

        private void CreateRecord(string record)
        {
            var label = new Label { Text = record };
            messages.AddChild(label);
        }

        private void OnMessageSaved(string message)
        {
            CreateRecord(message);
        }
    }
}

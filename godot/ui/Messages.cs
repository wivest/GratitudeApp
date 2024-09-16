using System.Collections.Generic;
using Godot;

namespace GratitudeApp
{
    [GlobalClass]
    public partial class Messages : VBoxContainer
    {
        private const string SAVE_PATH = "user://save.tres";

        [Export]
        private InputLine inputLine;
        private VBoxContainer messages;

        private Godot.Collections.Array<Label> messageNodes = new();

        public override void _Ready()
        {
            messages = GetNode<VBoxContainer>("Messages");
            LoadMessages();
            inputLine.MessageSaved += OnMessageSaved;
        }

        private void LoadMessages()
        {
            if (!ResourceLoader.Exists(SAVE_PATH))
                return;

            SaveData saveData = ResourceLoader.Load<SaveData>(SAVE_PATH);
            messageNodes = saveData.Messages;

            foreach (Label message in messageNodes)
            {
                messages.AddChild(message);
            }
        }

        private void SaveMessages()
        {
            var saveData = new SaveData { Messages = messageNodes };
            ResourceSaver.Save(saveData, SAVE_PATH);
        }

        private void CreateRecord(string record)
        {
            var label = new Label { Text = record };
            messages.AddChild(label);
            messageNodes.Add(label);
            SaveMessages();
        }

        private void OnMessageSaved(string message)
        {
            CreateRecord(message);
        }
    }
}

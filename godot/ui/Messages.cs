using System.Collections.Generic;
using Godot;
using Godot.Collections;
using GratitudeApp.Model;

namespace GratitudeApp
{
    [GlobalClass]
    public partial class Messages : VBoxContainer
    {
        private const string SAVE_PATH = "user://save.tres";

        [Export]
        private InputLine inputLine;
        private VBoxContainer messageNodes;
        private VBoxContainer peopleHints;

        private List<Message> messages = new();

        public override void _Ready()
        {
            messageNodes = GetNode<VBoxContainer>("Messages");
            peopleHints = GetNode<VBoxContainer>("PeopleHints");
            LoadMessages();
            inputLine.MessageSaved += OnMessageSaved;
            inputLine.PeopleMatched += OnPeopleMatched;
        }

        private void LoadMessages()
        {
            if (!ResourceLoader.Exists(SAVE_PATH))
                return;

            SaveData saveData = ResourceLoader.Load<SaveData>(SAVE_PATH);
            messages = new List<Message>(saveData.Messages);

            foreach (Message message in messages)
            {
                messageNodes.AddChild(new Label { Text = message.Text });
            }
        }

        private void SaveMessages()
        {
            var saveData = new SaveData { Messages = new Array<Message>(messages) };
            ResourceSaver.Save(saveData, SAVE_PATH);
        }

        private void CreateRecord(string record)
        {
            var label = new Label { Text = record };
            messageNodes.AddChild(label);
            messages.Add(new Message { Text = record });
            SaveMessages();
        }

        private void OnMessageSaved(string message)
        {
            CreateRecord(message);
        }

        private void OnPeopleMatched(List<Person> matched)
        {
            foreach (Node child in peopleHints.GetChildren())
                child.QueueFree();
            foreach (Person person in matched)
            {
                var personHint = new PersonHint { Text = $"{person.Name} (@{person.Tag})" };
                peopleHints.AddChild(personHint);
            }
        }
    }
}

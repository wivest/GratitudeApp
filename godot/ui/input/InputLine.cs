using System;
using Godot;

namespace GratitudeApp
{
    public partial class InputLine : Control
    {
        public event Action<string> MessageSaved;

        [Export]
        private Person[] people;

        private LineEdit lineEdit;
        private Button saveButton;

        public override void _Ready()
        {
            lineEdit = GetNode<LineEdit>("LineEdit");
            saveButton = GetNode<Button>("Button");

            saveButton.Pressed += OnMessageSaved;
            lineEdit.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(string text)
        {
            string lastWord = text.Split(' ')[^1];
            if (!lastWord.StartsWith('@'))
                return;
            string tag = lastWord.Split('@')[^1];

            foreach (Person person in people)
            {
                if (person.Tag.StartsWith(tag))
                    GD.Print(person.Name);
            }
        }

        private void OnMessageSaved()
        {
            string message = lineEdit.Text;
            lineEdit.Text = "";

            if (message != "")
            {
                MessageSaved(message);
            }
        }
    }
}

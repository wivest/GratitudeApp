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

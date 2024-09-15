using Godot;

namespace GratitudeApp
{
    public partial class Input : Control
    {
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
                GD.Print("Saved");
            }
        }
    }
}

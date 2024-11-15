using Godot;

namespace GratitudeApp;

public partial class PersonInput : HBoxContainer
{
    private LineEdit lineEdit;
    private Button saveButton;

    public override void _Ready()
    {
        lineEdit = GetNode<LineEdit>("LineEdit");
        saveButton = GetNode<Button>("Button");

        saveButton.Pressed += OnPersonSaved;
    }

    private void OnPersonSaved()
    {
        string name = lineEdit.Text;
        InputLine.People.Add(new Person { Name = name, Tag = name + "Tag" });
        lineEdit.Text = "";
    }
}

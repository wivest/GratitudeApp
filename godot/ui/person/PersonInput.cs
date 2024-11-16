using Godot;

namespace GratitudeApp;

public partial class PersonInput : HBoxContainer
{
    private LineEdit nameLineEdit;
    private LineEdit tagLineEdit;
    private Button saveButton;

    public override void _Ready()
    {
        nameLineEdit = GetNode<LineEdit>("Name");
        tagLineEdit = GetNode<LineEdit>("Tag");
        saveButton = GetNode<Button>("Button");

        saveButton.Pressed += OnPersonSaved;
    }

    private void OnPersonSaved()
    {
        string name = nameLineEdit.Text;
        string tag = tagLineEdit.Text;
        InputLine.People.Add(new Person { Name = name, Tag = tag });
        nameLineEdit.Text = "";
        tagLineEdit.Text = "";
    }
}

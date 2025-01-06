using System;
using Godot;
using GratitudeApp.Model;

namespace GratitudeApp.UI.People;

public partial class InputLine : HBoxContainer
{
    public event Action<PersonData> PersonSaved;

    [Export]
    private StatusLabel status;

    private LineEdit nameLineEdit;
    private LineEdit tagLineEdit;
    private Button saveButton;

    public override void _Ready()
    {
        nameLineEdit = GetNode<LineEdit>("Name");
        tagLineEdit = GetNode<LineEdit>("Tag");
        saveButton = GetNode<Button>("Save");

        saveButton.Pressed += OnPersonSaved;
        tagLineEdit.TextChanged += OnTagEdited;
    }

    private void OnTagEdited(string tag)
    {
        if (tag.Contains(' '))
        {
            status.Valid = false;
            status.Text = "Invalid character (' ') used!";
        }
        else
        {
            status.Valid = true;
            status.Text = "";
        }
    }

    private void OnPersonSaved()
    {
        if (!status.Valid)
            return;
        string name = nameLineEdit.Text;
        string tag = tagLineEdit.Text;
        nameLineEdit.Text = "";
        tagLineEdit.Text = "";
        PersonSaved?.Invoke(new PersonData { Name = name, Tag = tag });
    }
}

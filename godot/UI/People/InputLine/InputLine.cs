using System;
using Godot;
using GratitudeApp.Model;
using GratitudeApp.Model.Save;

namespace GratitudeApp.UI.People;

public partial class InputLine : HBoxContainer
{
    public event Action<PersonData> PersonSaved;

    [Export]
    private StatusLabel status;

    private LineEdit nameLineEdit;
    private LineEdit tagLineEdit;
    private Button saveButton;

    private readonly Saver<PeopleSave> saver = new("user://people.tres");

    public override void _Ready()
    {
        nameLineEdit = GetNode<LineEdit>("Name");
        tagLineEdit = GetNode<LineEdit>("Tag");
        saveButton = GetNode<Button>("Save");

        saveButton.Pressed += OnPersonSaved;
        tagLineEdit.TextChanged += OnTagEdited;

        OnTagEdited(tagLineEdit.Text);
    }

    private void OnTagEdited(string tag)
    {
        status.Valid = Validate(tag, out string message);
        status.Text = message;
    }

    private bool Validate(string tag, out string message)
    {
        string name = nameLineEdit.Text.Trim();
        if (name == "")
        {
            message = "Name cannot be empty!";
            return false;
        }
        foreach (PersonData p in saver.Load().People)
            if (p.Tag == tag)
            {
                message = "This tag already exists!";
                return false;
            }
        foreach (char c in tag)
            if ((c < 'a' || 'z' < c) && (c < '0' || '9' < c) && c != '_')
            {
                message = $"Invalid character ('{c}') used!";
                return false;
            }

        message = "";
        return true;
    }

    private void OnPersonSaved()
    {
        if (!status.Valid)
            return;
        string name = nameLineEdit.Text.Trim();
        string tag = tagLineEdit.Text;
        nameLineEdit.Text = "";
        tagLineEdit.Text = "";
        PersonSaved?.Invoke(new PersonData { Name = name, Tag = tag });
    }
}

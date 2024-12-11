using System.Collections.Generic;
using Godot;
using GratitudeApp.Model;

namespace GratitudeApp.UI.People;

public partial class InputLine : HBoxContainer
{
    public static List<Person> People { get; set; } = new();

    private LineEdit nameLineEdit;
    private LineEdit tagLineEdit;
    private Button saveButton;

    public override void _Ready()
    {
        nameLineEdit = GetNode<LineEdit>("Name");
        tagLineEdit = GetNode<LineEdit>("Tag");
        saveButton = GetNode<Button>("Save");

        saveButton.Pressed += OnPersonSaved;
    }

    private void OnPersonSaved()
    {
        string name = nameLineEdit.Text;
        string tag = tagLineEdit.Text;
        People.Add(new Person { Name = name, Tag = tag });
        nameLineEdit.Text = "";
        tagLineEdit.Text = "";
    }
}

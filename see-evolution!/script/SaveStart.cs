using Godot;
using System;

public partial class SaveStart : Button
{
	[Export]
	DrawChar drawChar;
	public override void _Ready()
	{
		Pressed += Onpressed;
	}
	public void Onpressed()
	{
		drawChar.SaveDrawing();
		GetTree().ChangeSceneToFile("res://tscn/StartToSee.tscn");
	}
}

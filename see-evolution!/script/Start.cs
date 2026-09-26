using Godot;
using System;

public partial class Start : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += LetsStart;
	}
	private void LetsStart()
	{
		GetTree().ChangeSceneToFile("res://tscn/choose.tscn");
	}
}

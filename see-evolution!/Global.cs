using Godot;
using System;

public partial class Global : Node
{
	public static Global Instance {get; set;}
	public float muscle {get; set;} = 0f; //clear all the value when we restarts
	public float active {get; set;} = 0f; //clear all the value when we restarts
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}
}

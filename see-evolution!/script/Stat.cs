using Godot;
using System;

public partial class Stat : HSlider
{
	[Signal]
	public delegate void StatChangedEventHandler();
	public override void _Ready()
	{
		ValueChanged += IfValueChanged;
	}

	private void IfValueChanged(double value)
	{
		if(Name == "muscle")
		{
			Global.Instance.muscle = (float)value;
		}
		else if(Name == "active")
		{
			Global.Instance.active = (float)value;
		}
		EmitSignal(SignalName.StatChanged);
	}
}

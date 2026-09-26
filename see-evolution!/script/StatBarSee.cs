using Godot;
using System;

public partial class StatBarSee : Label
{
	Stat statM;
	Stat statA;
	public override void _Ready()
	{
		if (Name == "muscleLabel")
		{
			Text = $"muscle(0~10)({Global.Instance.muscle})";
		}
		else if(Name == "activeLabel")
		{
			Text = $"active(0~10)({Global.Instance.active})";
		}
		statM = GetParent().GetNode<Stat>("muscle");
		statM.StatChanged += GoShowM;
		statA = GetParent().GetNode<Stat>("active");
		statA.StatChanged += GoShowA;
	}
	private void GoShowM()
	{
		if(Name == "muscleLabel")
		{
			Text = $"muscle(0~10)({Global.Instance.muscle})";
		}
	}
	private void GoShowA()
	{
		if(Name == "activeLabel")
		{
			Text = $"active(0~10)({Global.Instance.active})";
		}
	}
}

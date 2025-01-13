using Godot;
using System;
using Graph;

public partial class Main : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("What's good brah");
        Graph.Bag<int> bag = new();
        bag.Add(1);
        bag.Add(4);
        bag.Add(9);
        foreach (int item in bag)
        {
            GD.Print(item);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}

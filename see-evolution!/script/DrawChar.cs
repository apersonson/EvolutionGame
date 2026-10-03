using Godot;
using System.Collections.Generic;

public partial class DrawChar : Control
{
    private Viewport _viewport;
    
    // Stores all our brush strokes. Each stroke is a list of points.
    private List<List<Vector2>> _strokes = new List<List<Vector2>>();
    private List<Vector2> _currentStroke;
    
    private bool _isDrawing = false;

    public override void _Ready()
    {
        _viewport = GetViewport();
    }

    public override void _Input(InputEvent @event)
    {
        // 1. Start or stop drawing on click
        if (@event is InputEventMouseButton mouseButton && mouseButton.ButtonIndex == MouseButton.Left)
        {
            if (mouseButton.Pressed)
            {
                _isDrawing = true;
                _currentStroke = new List<Vector2>(); // Create a new brush stroke
                _currentStroke.Add(GetLocalMousePosition());
                _strokes.Add(_currentStroke); // Add it to our master list
                QueueRedraw();
            }
            else
            {
                _isDrawing = false; // Stop drawing when released
            }
        }
        // 2. Add points to the stroke while dragging
        else if (@event is InputEventMouseMotion && _isDrawing)
        {
            _currentStroke.Add(GetLocalMousePosition());
            QueueRedraw(); // Tell Godot to update the screen
        }
    }

    public override void _Draw()
    {
        // Loop through every stroke we've made
        foreach (var stroke in _strokes)
        {
            if (stroke.Count > 1)
            {
                // Draw a continuous smooth line through all points in the stroke
                // Parameters: points array, color, thickness, antialiasing (true/false)
                DrawPolyline(stroke.ToArray(), Colors.Red, 5.0f, true);
            }
            else if (stroke.Count == 1)
            {
                // If the user just clicked without dragging, draw a single dot
                DrawCircle(stroke[0], 2.5f, Colors.Red);
            }
        }
    }

    public void SaveDrawing()// it doesnt be used yet
    {
        string filepath = "user://Image/";
        if(FileAccess.FileExists(filepath))
        {   
            Error err = DirAccess.RemoveAbsolute(filepath);   
        }
        Image img = _viewport.GetTexture().GetImage();
        img.SavePng("user://Image/saved_drawing.png");
    }
}
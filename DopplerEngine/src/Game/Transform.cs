namespace DopplerEngine;

public class Transform
{
    public Vector2 Position;
    public Vector2 Scale;
    public float Rotation;

    public Transform(Vector2 position, Vector2 scale, float rotation)
    {
        Position = position;
        Scale = scale;
        Rotation = rotation;
    }

    public Transform(Vector2 position, Vector2 scale)
    {
        Position = position;
        Scale = scale;
    }

    public Transform(Vector2 position)
    {
        Position = position;
    }

    public Transform()
    {
        
    }
}
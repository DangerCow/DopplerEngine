namespace DopplerEngine;

public class Vector2
{
    public float X;
    public float Y;

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }
    
    public override string ToString() => $"({X}, {Y})";
    
    // Operators
    // Vector2 : Vector2
    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
    public static Vector2 operator *(Vector2 a, Vector2 b) => new(a.X * b.X, a.Y * b.Y);
    public static Vector2 operator /(Vector2 a, Vector2 b) => new(a.X / b.X, a.Y / b.Y);
    
    // Vector2 : float
    public static Vector2 operator +(Vector2 a, float b) => new(a.X + b, a.Y + b);
    public static Vector2 operator -(Vector2 a, float b) => new(a.X - b, a.Y - b);
    public static Vector2 operator *(Vector2 a, float b) => new(a.X * b, a.Y * b);
    public static Vector2 operator /(Vector2 a, float b) => new(a.X / b, a.Y / b);
    
    // float : Vector2
    public static Vector2 operator +(float a, Vector2 b) => new(a + b.X, a + b.Y);
    public static Vector2 operator -(float a, Vector2 b) => new(a - b.X, a - b.Y);
    public static Vector2 operator *(float a, Vector2 b) => new(a * b.X, a * b.Y);
    public static Vector2 operator /(float a, Vector2 b) => new(a / b.X, a / b.Y);
    
    // Statics
    public static readonly Vector2 Zero = new(0, 0);
    public static readonly Vector2 One = new(1, 1);
    public static readonly Vector2 Up = new(0, 1);
    public static readonly Vector2 Down = new(0, -1);
    public static readonly Vector2 Left = new(-1, 0);
    public static readonly Vector2 Right = new(1, 0);
    
    // Math
    // TODO: Add more math functions
    public static float Distance(Vector2 a, Vector2 b) => (b - a).Length();
    public float Distance(Vector2 b) => (b - this).Length();
    
    public float Length() => (float)Math.Sqrt(X * X + Y * Y);
}
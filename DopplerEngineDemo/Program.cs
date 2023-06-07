using DopplerEngine;

namespace DopplerEngineDemo;

public class Program
{
    public const int Width = 1280;
    public const int Height = 720;
    public const string Title = "Doppler Engine - Demo";
    
    public static void Main(string[] args)
    {
        Window.WindowSettings.Width = Width;
        Window.WindowSettings.Height = Height;
        Window.WindowSettings.Title = Title;
        Window.WindowSettings.EnableVsync();
        
        Window gameWindow = new();
        gameWindow.Open();
        gameWindow.Run();
    }
}
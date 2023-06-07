using Raylib_CsLo;
using static Raylib_CsLo.Raylib;

namespace DopplerEngine;

public class Window
{
    public static class WindowSettings
    {
        private static int _width = 1280;
        private static int _height = 720;

        private static string _title = "Doppler Engine - Untitled";

        private static int _targetFps = 60;

        private static bool _fullscreen;
        public static bool Vsync { get; internal set; }
        public static bool DrawFps { get; set; }

        public static bool IsOpen => !WindowShouldClose();

        public static int Width
        {
            get => _width;
            set
            {
                _width = value;
                if (IsOpen && !IsWindowFullscreen())
                    SetWindowSize(_width, _height);
            }
        }

        public static int Height
        {
            get => _height;
            set
            {
                _height = value;
                if (IsOpen && !IsWindowFullscreen())
                    SetWindowSize(_width, _height);
            }
        }

        public static string Title
        {
            get => _title;
            set
            {
                _title = value;
                if (IsOpen)
                    SetWindowTitle(_title);
            }
        }

        public static int TargetFps
        {
            get => _targetFps;
            set
            {
                _targetFps = value;
                if (IsOpen)
                    SetTargetFPS(_targetFps);
            }
        }

        #region FullScreen

        public static bool Fullscreen
        {
            get => _fullscreen;
            set
            {
                switch (value)
                {
                    case true:
                        EnableFullscreen();
                        break;
                    case false:
                        DisableFullscreen();
                        break;
                }
            }
        }

        public static void EnableFullscreen()
        {
            _fullscreen = true;

            if (IsOpen)
            {
                int monitor = GetCurrentMonitor();
                int monitorWidth = GetMonitorWidth(monitor);
                int monitorHeight = GetMonitorHeight(monitor);

                SetWindowSize(monitorWidth, monitorHeight);
                SetWindowPosition(0, 0);

                if (!IsWindowFullscreen())
                    ToggleFullscreen();
            }
        }

        public static void DisableFullscreen()
        {
            _fullscreen = false;

            if (IsOpen)
            {
                int monitor = GetCurrentMonitor();
                int monitorWidth = GetMonitorWidth(monitor);
                int monitorHeight = GetMonitorHeight(monitor);

                if (IsWindowFullscreen())
                    ToggleFullscreen();

                SetWindowSize(_width, _height);

                int windowX = monitorWidth / 2 - _width / 2;
                int windowY = monitorHeight / 2 - _height / 2;
                SetWindowPosition(windowX, windowY);
            }
        }

        #endregion

        public static void EnableVsync()
        {
            Vsync = true;
            if (IsOpen)
                SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
        }
    }

    public void Open()
    {
        InitWindow(WindowSettings.Width, WindowSettings.Height, WindowSettings.Title);
        if (WindowSettings.Fullscreen)
            WindowSettings.EnableFullscreen();
        if (WindowSettings.Vsync)
            WindowSettings.EnableVsync();

        int monitor = GetCurrentMonitor();
        int monitorRefreshRate = GetMonitorRefreshRate(monitor);
        WindowSettings.TargetFps = monitorRefreshRate;

        InitAudioDevice();
    }

    public void Run()
    {
        while (WindowSettings.IsOpen)
        {
            BeginDrawing();
            {
                ClearBackground(BLACK);
            }
            EndDrawing();
        }
    }
}
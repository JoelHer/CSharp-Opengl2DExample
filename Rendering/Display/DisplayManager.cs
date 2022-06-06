using GLFW;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using static OpenGLTest.OpenGL.GL;

namespace OpenGLTest.Rendering.Display
{
    class DisplayManager
    {
        public static Window Window { get; set; }
        public static Vector2 WindowSize { get; set; }
        public static bool WindowResizeable { get; set; }
        
        public static void CreateWindow(int width, int height, string title, bool resizable = false)
        {
            WindowSize = new Vector2(width, height);

            WindowResizeable = resizable;

            Glfw.Init();

            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
                        
            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, WindowResizeable);


            Window = Glfw.CreateWindow(width, height, title, Monitor.None, Window.None);

            if (Window == Window.None)
            {
                //TODO: Show Error Dialog
                return;
            }

            Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
            int x = (screen.Width - width) / 2;
            int y = (screen.Height - height) / 2;

            Glfw.SetWindowPosition(Window, x, y);

            Glfw.MakeContextCurrent(Window);
            Import(Glfw.GetProcAddress);

            glViewport(0, 0, width, height);
            Glfw.SwapInterval(1); //Vsync off = 0, On = 1
        }

        public static void CloseWindows()
        {
            Glfw.Terminate();
        }
    }
}

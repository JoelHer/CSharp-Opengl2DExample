using GLFW;
using OpenGLTest.Rendering.Display;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGLTest.GameLoop
{
    abstract class Game
    {

        protected int InitialWindowWidth { get; set; }
        protected int InitialWindowHeight { get; set; } 
        protected string InitialWindowTitle { get; set; } 

        public Game(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle)
        {
            InitialWindowWidth = initialWindowWidth;
            InitialWindowHeight = initialWindowHeight;
            InitialWindowTitle = initialWindowTitle;
        }

        public void Run()
        {
            Initialize();

            DisplayManager.CreateWindow(InitialWindowWidth, InitialWindowHeight, InitialWindowTitle);

            LoadContent();

            while (!Glfw.WindowShouldClose(DisplayManager.Window))
            {
                GameTime.DeltaTime = (float)Glfw.Time - GameTime.TotalElapsedSeconds;
                GameTime.TotalElapsedSeconds = (float)Glfw.Time;
                    
                Update();

                Glfw.PollEvents();

                Render();
            }

            DisplayManager.CloseWindows();
        }

        protected abstract void Initialize();
        protected abstract void LoadContent();

        protected abstract void Update();
        protected abstract void Render();
    }
}

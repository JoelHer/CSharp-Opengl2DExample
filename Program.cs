using OpenGLTest.GameLoop;

namespace OpenGLTest
{
    class Programm
    {
        public static void Main(string[] args)
        {
            Game game = new TestGame(800, 600, "HelloWorld");
            game.Run();
        }
    }
}
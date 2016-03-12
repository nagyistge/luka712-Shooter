using ShooterGame.GameObjects;
using ShooterGame.Utilities;
using ShooterGame.Utilities.Implementation;
using ShooterGame.Utilities.Interface;
using System;

namespace ShooterGame
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ILoader loader = new Loader();
            ISettings settings = new Settings();
            ISpawnTimes spawnTimes = new SpawnTimes();
            using (var game = new Game1(loader, settings, spawnTimes))
            {
                game.Run();
            }
        }
    }
#endif
}

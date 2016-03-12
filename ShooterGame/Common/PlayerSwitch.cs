using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Common
{
    /// <summary>
    /// Gets and sets player switch.
    /// </summary>
    public static class PlayerSwitch
    {
        public static Player Player1 = new Player();
        public static Player Player2 = new Player();

        /// <summary>
        /// Gets or sets number of players.
        /// </summary>
        public static Players NumberOfPlayers { get; set; }

        /// <summary>
        /// Sets player that uses gamepad.
        /// </summary>
        public static void SetGamepad(Index player, bool useGamepad)
        {
            if(player == Index.One)
            {
                if(useGamepad)
                {
                    Player1.Gamepad = true;
                    Player2.Gamepad = false;
                }
                else
                {
                    Player1.Gamepad = false;
                    Player2.Gamepad = true;
                }
            }
            else
            {
                if(useGamepad)
                {
                    Player1.Gamepad = false;
                    Player2.Gamepad = true;
                }
                else
                {
                    Player1.Gamepad = true;
                    Player2.Gamepad = false;
                }
            }
        }

        public class Player
        {
            public bool Gamepad { get; set; }
        }
    }
}

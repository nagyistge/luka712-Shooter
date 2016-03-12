using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameState.States
{
    public abstract class BaseState
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="game">Game reference.</param>
        public BaseState(Game1 game)
        {
            Game = game;
            Active = true;
        }

        /// <summary>
        /// Initalizer. Should be called when state is created.
        /// </summary>
        public abstract void Initalize();

        /// <summary>
        /// Gets rid of resources.
        /// </summary>
        public abstract void EndState();

        /// <summary>
        /// Holds reference to game.
        /// </summary>
        public Game1 Game{ get; private set; }

        /// <summary>
        /// Checks if state is Active.
        /// </summary>
        public bool Active { get; set; }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects.Enemies
{
    public abstract class BaseEnemy : SpriteObject
    {
        #region Constructors

        public BaseEnemy(Game1 game, Texture2D texture)
            : base(game, texture)
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets direction.
        /// </summary>
        public virtual Vector2 Direction { get; set; }

        /// <summary>
        /// Gets and sets speed.
        /// </summary>
        public float Speed { get; set; }

        #endregion
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects.Enemies
{
    public sealed class Asteroid : BaseEnemy
    {
          #region Constructors

        public Asteroid(Game1 game, Texture2D texture, Vector2 position, float speed)
            : base(game, texture)
        {
            Direction = -Vector2.UnitX;
            Active = true;
            Position = position;
            Speed = speed;
        }

        #endregion

        #region Properties
        
        #endregion

        #region Methods

        /// <summary>
        /// Updates asteroids.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(Position.X - Texture.Width * Size.X < 0)
            {
                Active = false;
            }
        }

        #endregion
    }
}

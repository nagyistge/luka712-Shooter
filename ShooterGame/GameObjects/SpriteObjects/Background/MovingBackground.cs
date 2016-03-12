using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects.Background
{
    /// <summary>
    /// Creates moving background.
    /// </summary>
    public class MovingBackground : SpriteObject, ICloneable
    {
        #region Fields

        private Rectangle drawRectangle;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MovingBackground(Game1 game, Texture2D texture, Rectangle drawRect, Vector2 direction, float speed)
            :base(game, texture)
        {
            drawRectangle = drawRect;
            Direction = direction;
            Speed = speed;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Draw rectangle.
        /// </summary>
        public Rectangle DrawRectangle
        {
            get { return drawRectangle; }
            set { drawRectangle = value; }
        }

        /// <summary>
        /// Movement speed.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Direction.
        /// </summary>
        public Vector2 Direction { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Updates moving background
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            drawRectangle.X += (int)(Direction.X * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            drawRectangle.Y += (int)(Direction.Y * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds);

            if (drawRectangle.X < -drawRectangle.Width + 1)
                drawRectangle.X = drawRectangle.Width;
            else if (drawRectangle.X > drawRectangle.Width - 1)
                drawRectangle.X = -drawRectangle.Width;
        }

        /// <summary>
        /// Draws background.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;

            spriteBatch.Draw(Texture, drawRectangle, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, LayerDepth);
        }

        /// <summary>
        /// Creates clone of moving background.
        /// </summary>
        public object Clone()
        {
            return new MovingBackground(this.Game, this.Texture, this.drawRectangle, this.Direction, this.Speed)
            {
                LayerDepth = this.LayerDepth
            };
        }

        #endregion

      
    }
}

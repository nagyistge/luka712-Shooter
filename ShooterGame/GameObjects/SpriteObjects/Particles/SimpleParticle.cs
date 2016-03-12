using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects.Particles
{
    public class SimpleParticle : SpriteObject, ICloneable
    {

        #region Constructors

        public SimpleParticle(Game1 game, Texture2D texture)
            :base(game, texture)
        {
            Active = false;
        }

        /// <summary>
        /// Particle constructor.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public SimpleParticle(Game1 game, Texture2D texture, Vector2 position, Vector2 direction, float speed, float scale)
            :this(game, texture)
        {
            Direction = direction;
            Speed = speed;
            Scale = scale;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets direction.
        /// </summary>
        public Vector2 Direction { get; set; }

        /// <summary>
        /// Gets or sets particle speed.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Gets or sets particle scale.
        /// </summary>
        public float Scale { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Updates snow particle.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        /// <summary>
        /// Draws game.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;

            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero,Scale, SpriteEffects.None, LayerDepth);
        }

        /// <summary>
        /// Crates same instance.
        /// </summary>
        public object Clone()
        {
            return new SimpleParticle(Game, Texture, Position, Direction, Speed, Scale);
        }

        #endregion

    }
}

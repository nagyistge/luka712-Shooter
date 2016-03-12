using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects.Animations
{
    /// <summary>
    /// Sprite animation class.
    /// </summary>
    public class SpriteAnimation : BaseAnimation
    {
        #region Fields

        private readonly int _numberOfFrames;
        private int currentFrame;
        private Rectangle sourceRect;
        private Rectangle drawRect;

        #endregion

        #region Constructors

        public SpriteAnimation(Game1 game, Texture2D texture, Vector2 position, Vector2 size, int numberOfFrames)
            : base(game, texture)
        {
            drawRect = new Rectangle((int)position.X, (int)position.Y,
                (int)size.X, (int)size.Y);
            SourceRect = new Rectangle(0, 0, (int)(texture.Width / numberOfFrames), texture.Height);
            Origin = new Vector2(size.X * .5f, size.Y * .5f);
            PlayAnimation = true;
            _numberOfFrames = numberOfFrames;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets sprite animation position.
        /// </summary>
        public override Vector2 Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                drawRect.X = (int)base.Position.X;
                drawRect.Y = (int)base.Position.Y;
            }
        }

        /// <summary>
        /// Gets or sets draw rectangle.
        /// </summary>
        public virtual Rectangle DrawRect
        {
            get { return drawRect; }
            set { drawRect = value; }
        }

        /// <summary>
        /// Gets or sets source rectangle.
        /// </summary>
        public virtual Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        /// <summary>
        /// Plays sprite animation.
        /// </summary>
        public virtual bool PlayAnimation { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Updates sprite animation.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            if (!PlayAnimation) return;

            if (currentFrame < _numberOfFrames)
            {
                sourceRect.X = currentFrame * SourceRect.Width;
                currentFrame++;
                if (currentFrame >= _numberOfFrames) currentFrame = 0;
            }
        }

        /// <summary>
        /// Draws sprite animation.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, drawRect, sourceRect, Color, Rotation, Origin, SpriteEffects.None, LayerDepth);
        }

        #endregion
    }
}

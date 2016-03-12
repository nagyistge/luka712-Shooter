using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects.Animations
{

    /// <summary>
    /// Fades screen in, or out.
    /// </summary>
    public sealed class FadeAnimation : BaseAnimation, ICloneable
    {
        #region Fields

        private readonly Rectangle _drawRectangle;
        private float fade;
        private bool fadeIn;
        private bool fadeOut;

        #endregion

        #region Events

        /// <summary>
        /// Notify subscrubires when animation is fully faded out.
        /// </summary>
        public event OnFadedOut OnFadedOut;

        /// <summary>
        /// Notify subscrubires when animation is fully faded in.
        /// </summary>
        public event OnFadedIn OnFadedIn;

        #endregion

        #region Constructors

        /// <summary>
        /// Sprite object constructor.
        /// </summary>
        /// <param name="game">Main Game reference.</param>
        /// <param name="texture">Texture to draw.</param>
        public FadeAnimation(Game1 game, Texture2D texture)
            : base(game, texture)
        {
            _drawRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            fadeIn = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets fade.
        /// Fade is clamped to range 0.0 to 1.0
        /// </summary>
        public float Fade
        {
            get { return fade; }
            set
            {
                if (value < 0.0f)
                    value = 0.0f;
                else if (value > 1.0f)
                    value = 1.0f;
                fade = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates shallow copy of fade animation.
        /// </summary>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Updates fade animation.
        /// </summary>
        /// <param name="gameTime">GameTime.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Fading in
            if (Fade < 1.0f && fadeIn)
            {
                Fade += (float)gameTime.ElapsedGameTime.TotalSeconds * AnimationSettings.FadeSpeed;
                if (Fade >= 1.0f)
                {
                    FadedInNotifier();
                    fadeIn = false;
                }
            }
            // Fading out
            else if(Fade > 0.0f && fadeOut)
            {
                Fade -= (float)gameTime.ElapsedGameTime.TotalSeconds * AnimationSettings.FadeSpeed;
                if (Fade <= 0.0f)
                {
                    FadedOutNotifier();
                    fadeOut = false;
                }
            }
        }

        /// <summary>
        /// Draws game objects.
        /// </summary>
        /// <param name="spriteBatch">Spritebatch instance.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
            spriteBatch.Draw(Texture, _drawRectangle, null, Color * Fade, 0f, Vector2.Zero, SpriteEffects.None, LayerDepth);
        }

        /// <summary>
        /// Stars fading in.
        /// </summary>
        /// <param name="resetFadeAmount">If set resets fade amount to 0.</param>
        public void FadeIn(bool resetFadeAmount = false)
        {
            if (resetFadeAmount) Fade = 0.0f;
            fadeIn = true;
        }

        /// <summary>
        /// Starts fading out.
        /// </summary>
        /// <param name="resetFadeAmount">If sets stars from fully faded screen.</param>
        public void FadeOut(bool resetFadeAmount = false)
        {
            if (resetFadeAmount) Fade = 1.0f;
            fadeOut = true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Notifies subscribers.
        /// </summary>
        private void FadedOutNotifier()
        {
            if (OnFadedOut != null)
            {
                OnFadedOut(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Notifies subscribers.
        /// </summary>
        private void FadedInNotifier()
        {
            if (OnFadedIn != null)
            {
                OnFadedIn(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}

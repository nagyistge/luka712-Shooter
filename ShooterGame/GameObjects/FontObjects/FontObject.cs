using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.FontObjects
{
    /// <summary>
    /// Font Object
    /// </summary>
    public class FontObject : GameObject
    {
        #region Fields

        private readonly Vector2 _initialPosition;
        private readonly string _initialText;
        private readonly Color _initialColor;

        #endregion


        #region Constructors

        /// <summary>
        /// The constructor for text object.
        /// </summary>
        /// <param name="game">Game reference.</param>
        /// <param name="font">Font style.</param>
        /// <param name="text">Text to show.</param>
        /// <param name="color">Text color.</param>
        public FontObject(Game1 game, SpriteFont font, string text, Color color)
            : this(game, font, text, Vector2.Zero, color)
        {

        }

        /// <summary>
        /// The constructor for text object.
        /// </summary>
        /// <param name="game">Game reference.</param>
        /// <param name="font">Font style.</param>
        /// <param name="text">Text to show.</param>
        /// <param name="position">Position of text.</param>
        public FontObject(Game1 game, SpriteFont font, string text, Vector2 position)
            : this(game, font, text, position, Color.White)
        {

        }

        /// <summary>
        /// The constructor for text object.
        /// </summary>
        /// <param name="game">Game reference.</param>
        /// <param name="font">Font style.</param>
        /// <param name="text">Text to show.</param>
        public FontObject(Game1 game, SpriteFont font, string text)
            : this(game, font, text, Vector2.Zero, Color.White)
        {

        }

        /// <summary>
        /// The constructor for text object.
        /// </summary>
        /// <param name="game">Game reference</param>
        /// <param name="font">Font style.</param>
        /// <param name="text">Text to show.</param>
        /// <param name="position">Position of text.</param>
        /// <param name="color">Text color.</param>
        public FontObject(Game1 game, SpriteFont font, string text, Vector2 position, Color color)
        {
            Game = game;
            Font = font;
            Text = text;
            Position = position;
            Color = color;
            _initialPosition = position;
            _initialColor = color;
            _initialText = text;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Object font style.
        /// </summary>
        public virtual SpriteFont Font { get; protected set; }

        /// <summary>
        /// Text to show.
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// Text position on screen.
        /// </summary>
        public virtual Vector2 Position { get; set; }

        /// <summary>
        /// Font color.
        /// </summary>
        public virtual Color Color { get; set; }

        /// <summary>
        /// Gets or sets layer depth.
        /// </summary>
        public float LayerDepth { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Reset to inital state.
        /// </summary>
        public override void ResetObject()
        {
            Position = _initialPosition;
            Text = _initialText;
            Color = _initialColor;
        }

        /// <summary>
        /// Draw fonts.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(Font, Text, Position, Color, 0f, Vector2.Zero, 1, SpriteEffects.None, LayerDepth);
        }

        #endregion


    }
}

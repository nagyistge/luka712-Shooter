using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects
{
    /// <summary>
    /// Game objects that draws simple sprites 
    /// and represents base class for other sprite objects.
    /// </summary>
    public class SpriteObject : GameObject
    {
        #region Fields

        private readonly Vector2 _initalPosition;
        private readonly Vector2 _initalSize;

        #endregion


        #region Constructors

        /// <summary>
        /// Sprite object constructor.
        /// </summary>
        /// <param name="game">Main Game reference.</param>
        /// <param name="texture">Texture to draw.</param>
        public SpriteObject(Game1 game, Texture2D texture)
            :this(game, texture, Vector2.Zero, Vector2.One)
        {

        }

        /// <summary>
        /// Sprite object constructor.
        /// </summary>
        /// <param name="game">Main Game reference.</param>
        /// <param name="texture">Texture to draw.</param>
        /// <param name="position">Drawing position.</param>
        public SpriteObject(Game1 game, Texture2D texture, Vector2 position)
            : this(game, texture, position, Vector2.One)
        {

        }

        /// <summary>
        /// Sprite object constructor.
        /// </summary>
        /// <param name="game">Main Game reference.</param>
        /// <param name="texture">Texture to draw.</param>
        /// <param name="position">Drawing position.</param>
        /// <param name="size">Object size.</param>
        public SpriteObject(Game1 game, Texture2D texture, Vector2 position, Vector2 size)
        {
            Game = game;
            Texture = texture;
            _initalPosition = position;
            _initalSize = size;
            ResetObject();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Holds texture to draw.
        /// </summary>
        public virtual Texture2D Texture { get; protected set; }

        /// <summary>
        /// Objects position on screen space.
        /// </summary>
        public virtual Vector2 Position { get; set; }

        /// <summary>
        /// Objects size.
        /// </summary>
        public virtual Vector2 Size { get; set; }

        /// <summary>
        /// Object rotation.
        /// </summary>
        public virtual float Rotation { get; set; }
        
        /// <summary>
        /// Drawing color.
        /// </summary>
        public virtual Color Color { get; set; }

        /// <summary>
        /// Drawing origin.
        /// </summary>
        public virtual Vector2 Origin { get; set; }

        /// <summary>
        /// Gets or sets layer depth ( drawing order ).
        /// </summary>
        public float LayerDepth { get; set; }

        /// <summary>
        /// Returns texture name. Usefull for texture sorting.
        /// </summary>
        public string TextureName
        {
            get
            {
                if(Texture != null)
                {
                    return Texture.Name;
                }
                return String.Empty;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws game objects.
        /// </summary>
        /// <param name="spriteBatch">Spritebatch instance.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (Texture == null) return;

            spriteBatch.Draw(Texture, Position, null, Color, Rotation, Origin, Size, SpriteEffects.None, LayerDepth);
        }

        /// <summary>
        /// Reset object to inital state.
        /// </summary>
        public override void ResetObject()
        {
            Active = true;
            Position = _initalPosition;
            Size = _initalSize;
            Color = Color.White;

            // If there is texture, set origin to be in middle of texture.
            if (Texture != null)
                Origin = new Vector2(Texture.Width * .5f, Texture.Height * .5f);
        }

        #endregion

    }
}

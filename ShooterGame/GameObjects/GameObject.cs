using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects
{
    /// <summary>
    /// Abstract game objects class.
    /// </summary>
    public abstract class GameObject
    {
        #region Properties

        /// <summary>
        /// Indicates if objects is active and ready to update and draw.
        /// </summary>
        public virtual bool Active { get; set; }

        /// <summary>
        /// Holds reference to game.
        /// </summary>
        public Game1 Game { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// Updates object.
        /// </summary>
        /// <param name="gameTime">Passed gametime.</param>
        public virtual void Update(GameTime gameTime)
        {
            if (!Active) return;
        }

        /// <summary>
        /// Draws game objects.
        /// </summary>
        /// <param name="spriteBatch">Spritebatch instance.</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
        }

        /// <summary>
        /// Resets object to inital state.
        /// </summary>
        public abstract void ResetObject();
        
        #endregion

       
    }
}

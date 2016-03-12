using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects.Animations
{
    /// <summary>
    /// Base animation class. Holds only IAnimationSettings.
    /// </summary>
    public class BaseAnimation : SpriteObject
    {
        private IAnimationSettings animationSettings;

        /// <summary>
        /// Gets and sets animation settings.
        /// If not set by user uses default animation settings.
        /// </summary>
        public IAnimationSettings AnimationSettings
        {
            get
            {
                if (animationSettings == null) 
                    animationSettings = new AnimationSettings();
                return animationSettings;
            }
            set
            {
                animationSettings = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseAnimation(Game1 game, Texture2D texture)
            : base(game, texture) { }

    }
}

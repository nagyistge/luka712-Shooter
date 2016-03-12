using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities
{
    /// <summary>
    /// Loader contract. Benefit of using this is that new textures and implementation could be easily loaded.
    /// </summary>
    public interface ILoader
    {
        /// <summary>
        /// Loads textures and fonts.
        /// </summary>
        void Load(ContentManager contentManager, GraphicsDevice graphicsDevice);

        /// <summary>
        /// Gets pixel texture.
        /// </summary>
        Texture2D PixelTexture { get; }

        /// <summary>
        /// Gets logo texture.
        /// </summary>
        Texture2D LogoTexture { get; }

        /// <summary>
        /// Gets game font.
        /// </summary>
        SpriteFont GameFont { get; }

        /// <summary>
        /// Gets main background.
        /// </summary>
        Texture2D MainBackground { get; }

        /// <summary>
        /// Gets background layer.
        /// </summary>
        Texture2D BackgroundLayer1 { get; }

        /// <summary>
        /// Gets background layer.
        /// </summary>
        Texture2D BackgroundLayer2 { get; }

        /// <summary>
        /// Gets texture for player 1.
        /// </summary>
        Texture2D Player1Texture { get; }

        /// <summary>
        /// Gets texture for player 2.
        /// </summary>
        Texture2D Player2Texture { get; }

        /// <summary>
        /// Get snow texture.
        /// </summary>
        Texture2D SnowTexture { get; }
    }
}

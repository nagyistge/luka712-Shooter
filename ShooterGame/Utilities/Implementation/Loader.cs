using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities
{
    /// <summary>
    /// Loads textures and fonts.
    /// Method Load needs to be called before textures and fonts can be used.
    /// </summary>
    public class Loader : ILoader
    {
        #region Fields

        private const int SNOW_RADIUS = 10;

        #endregion

        #region Properties

        /// <summary>
        /// Gets pixel texture.
        /// </summary>
        public Texture2D PixelTexture { get; private set; }

        /// <summary>
        /// Gets logo texture.
        /// </summary>
        public Texture2D LogoTexture { get; private set; }

        /// <summary>
        /// Game font.
        /// </summary>
        public SpriteFont GameFont { get; private set; }

        /// <summary>
        /// Gets main background.
        /// </summary>
        public Texture2D MainBackground { get; private set; }

        /// <summary>
        /// Gets background layer.
        /// </summary>
        public Texture2D BackgroundLayer1 { get; private set; }

        /// <summary>
        /// Gets background layer.
        /// </summary>
        public Texture2D BackgroundLayer2 { get; private set; }

        /// <summary>
        /// Gets texture for player 1.
        /// </summary>
        public Texture2D Player1Texture { get; private set; }

        /// <summary>
        /// Gets texture for player 2.
        /// </summary>
        public Texture2D Player2Texture { get; private set; }

        /// <summary>
        /// Gets snow texture.
        /// </summary>
        public Texture2D SnowTexture { get; private set; }

        /// <summary>
        /// Returns asteroids textures with info.
        /// </summary>
        public TextArrayInfo AsteroidTextures { get; private set; }
 
       
        #endregion

        #region Methods

        /// <summary>
        /// Loads game assets.
        /// </summary>
        /// <param name="contentManager">Content Manager.</param>
        /// <param name="graphicsDevice">Graphics Device.</param>
        public void Load(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            // Simple 1x1 pixel.
            PixelTexture = new Texture2D(graphicsDevice, 1, 1);
            PixelTexture.SetData<Color>(new Color[1] { Color.White });

            LogoTexture = contentManager.Load<Texture2D>("Logo");

            GameFont = contentManager.Load<SpriteFont>("GameFont");

            MainBackground = contentManager.Load<Texture2D>("mainbackground");

            BackgroundLayer1 = contentManager.Load<Texture2D>("bgLayer1");

            BackgroundLayer2 = contentManager.Load<Texture2D>("bgLayer2");

            Player1Texture = contentManager.Load<Texture2D>("player1");

            Player2Texture = contentManager.Load<Texture2D>("player2");

            SnowTexture = new Texture2D(graphicsDevice, SNOW_RADIUS * 2, SNOW_RADIUS * 2);
            SnowTexture.SetData<Color>(SnowData());

            var asteroidTextures = new Texture2D[6];
            asteroidTextures[0] = contentManager.Load<Texture2D>("meteorBrown_big2");
            asteroidTextures[1] = contentManager.Load<Texture2D>("meteorBrown_med1");
            asteroidTextures[2] = contentManager.Load<Texture2D>("meteorBrown_med3");
            asteroidTextures[3] = contentManager.Load<Texture2D>("meteorGrey_med1");
            asteroidTextures[4] = contentManager.Load<Texture2D>("meteorGrey_med2");
            asteroidTextures[5] = contentManager.Load<Texture2D>("meteorGrey_small1");
            AsteroidTextures = new TextArrayInfo(asteroidTextures);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create snow data.
        /// </summary>
        private Color[] SnowData()
        {
            int snowDiameter = SNOW_RADIUS * 2;
            Color[] data = new Color[(int)Math.Pow(snowDiameter, 2)];
            int k = 0;
            for(int i = -SNOW_RADIUS; i < SNOW_RADIUS; i++)
            {
                for(int j = -SNOW_RADIUS;j < SNOW_RADIUS; j++)
                {
                    if (Math.Pow(i, 2) + Math.Pow(j, 2) <= snowDiameter)
                    {
                        data[k] = Color.White;
                    }
                    else
                    {
                        data[k] = Color.Transparent;
                    }
                    k++;
                }
            }

            return data;
        }

        #endregion
    }
}

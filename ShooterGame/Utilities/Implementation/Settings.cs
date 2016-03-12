using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities
{
    /// <summary>
    /// Provides game settings.
    /// </summary>
    public class Settings : ISettings
    {
        #region Fields

        private float[] _backgroundSpeed;

        #endregion

        #region Constructors
        
        public Settings()
        {
            _backgroundSpeed = new float[3] { 0.13f, 0.12f, 0.11f };
        }

        #endregion

        /// <summary>
        /// Returns array of background speeds.
        /// </summary>
        public float[] BackgroundSpeed
        {
            get { return _backgroundSpeed; }
        }

        /// <summary>
        /// Returns player speed.
        /// </summary>
        public float PlayerSpeed
        {
            get { return .15f; }
        }

        /// <summary>
        /// Internally it's random, this is added to random speed.
        /// </summary>
        public float SnowSpeed
        {
            get { return .5f; }
        }

        /// <summary>
        /// Asteroid speed.
        /// </summary>
        public float AsteroidSpeed
        {
            get { return .1f; }
        }
    }
}

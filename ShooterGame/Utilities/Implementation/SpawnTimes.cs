using ShooterGame.Utilities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities.Implementation
{
    /// <summary>
    /// Holds all spawn times.
    /// </summary>
    public class SpawnTimes : ISpawnTimes
    {
        /// <summary>
        /// Snow particle spawn time.
        /// </summary>
        public float SnowParticleSpawnTime
        {
            get { return .25f; }
        }

        /// <summary>
        /// Asteroid spawn time.
        /// </summary>
        public float AsteroidSpawnTime
        {
            get { return 2f; }
        }
    }
}

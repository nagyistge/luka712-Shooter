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
        public float SnowParticleSpawnTime
        {
            get { return .25f; }
        }
    }
}

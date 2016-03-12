using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities.Interface
{
    /// <summary>
    /// Spawn times contract.
    /// </summary>
    public interface ISpawnTimes
    {
        float SnowParticleSpawnTime { get; }
        float AsteroidSpawnTime { get; }
     }
}

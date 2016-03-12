using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities
{
    /// <summary>
    /// Contract for game settings.
    /// </summary>
    public interface ISettings
    {
        float[] BackgroundSpeed { get; }
        float PlayerSpeed { get; }
        float SnowSpeed { get; }
    }
}

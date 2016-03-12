using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities
{
    public interface IAnimationSettings
    {
        float FadeSpeed { get; }
        float FrameChangeSpeed { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities
{
    public class AnimationSettings : IAnimationSettings
    {
        public float FadeSpeed { get { return 0.5f; } }
        public float FrameChangeSpeed { get { return 0.2f; } }
    }
}

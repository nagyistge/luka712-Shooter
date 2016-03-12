using ShooterGame.Utilities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities.Implementation
{
    public class LayerDepth : ILayerDepth
    {
        public float EnemyLayerDepth { get { return 0.004f; } }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities
{
    /// <summary>
    /// Helper functions.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Ease in function. 
        /// </summary>
        /// <param name="from">Starting point.</param>
        /// <param name="to">End point.</param>
        /// <param name="amount">Transition speed.</param>
        /// <returns>Current position.</returns>
        public static Vector2 EaseIn(Vector2 from, Vector2 to, float amount)
        {
            Vector2 result = to - from;
            result.X = (float)(Math.Sqrt(Math.Abs(result.X))) * NegativeOrPositive(result.X) * amount;
            result.Y = (float)(Math.Sqrt(Math.Abs(result.Y))) * NegativeOrPositive(result.Y) * amount;
            from += result;
            return from;
        }

        /// <summary>
        /// Ease out function.
        /// </summary>
        /// <param name="from">Starting point.</param>
        /// <param name="to">End point.</param>
        /// <param name="amount">Transition speed.</param>
        /// <returns>Current position.</returns>
        public static Vector2 EaseOut(Vector2 from, Vector2 to, float amount)
        {
            Vector2 result = to - from;
            result.X = (float)(Math.Pow(Math.Abs(result.X), 1.005)) * NegativeOrPositive(result.X) * amount;
            result.Y = (float)(Math.Pow(Math.Abs(result.Y), 1.005)) * NegativeOrPositive(result.Y) * amount;
            from += result;
            return from;
        }

        /// <summary>
        /// Return 1 or -1 depending 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static float NegativeOrPositive(float num)
        {
            if (num < 0f)
                return -1f;
            else
                return 1f;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Common
{
    /// <summary>
    /// Represents horizontal alignment.
    /// </summary>
    public enum HorizontalAlignment
    {
        Left, Center, Right
    }

    /// <summary>
    /// Represents vertical alignment.
    /// </summary>
    public enum VerticalAlignment
    {
        Top, Center, Bottom
    }

    /// <summary>
    /// Text alignment.
    /// </summary>
    public enum TextAlignment
    {
        Vertical, Horizontal
    }

    /// <summary>
    /// Sets number of players.
    /// </summary>
    public enum Players
    {
        One, Two
    }

    /// <summary>
    /// Player index, for exmaple if player is first or second player.
    /// </summary>
    public enum Index
    {
        One, Two
    }
}

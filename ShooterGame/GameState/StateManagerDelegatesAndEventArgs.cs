using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameState
{
    /// <summary>
    /// On state change delegate.
    /// </summary>
    public delegate void OnStateChange(object sender, StateChangeEventArgs eventArgs);

    /// <summary>
    /// Holds state info.
    /// </summary>
    public sealed class StateChangeEventArgs : EventArgs
    {
        public StateChangeEventArgs(State newState, State oldState)
        {
            NewState = newState;
            OldState = oldState;
        }

        public State NewState { get; set; }
        public State OldState { get; set;}
    }
}

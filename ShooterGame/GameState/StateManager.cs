using Microsoft.Xna.Framework;
using ShooterGame.GameObjects.SpriteObjects.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameState
{
    /// <summary>
    /// State manager. Takes care of keeping current state and changing state.
    /// </summary>
    public sealed class StateManager 
    {
        #region Fields

        private static readonly StateManager _instance = new StateManager();
        private FadeAnimation fadeAnimation;
        private State pendingState;

        #endregion

        #region Events

        public event OnStateChange OnStateChange;

        #endregion

        #region Properties

        /// <summary>
        /// Return state manager instance.
        /// </summary>
        public static StateManager Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Current Game State.
        /// public getter.
        /// </summary>
        public State GameState { get; private set; }

        /// <summary>
        /// FadeAnimation, can be set only once.
        /// </summary>
        public FadeAnimation FadeAnimation
        {
            get 
            { 
                if(fadeAnimation == null)
                    throw new NotImplementedException("FadeAnimation");

                return fadeAnimation;
            }
            set
            {
                if (fadeAnimation == null && value != null)
                {
                    // Create copy of object, since manager needs to have it's own object.
                    // Also add new copy to game.
                    fadeAnimation = (FadeAnimation)value.Clone();
                    fadeAnimation.LayerDepth = 1f;
                    fadeAnimation.Game.GameObjects.AddGameObject(fadeAnimation);
                    fadeAnimation.OnFadedIn += fadeAnimation_OnFadedIn;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Changes game state.
        /// </summary>
        public void ChangeState(State state)
        {
            // Start fading in and set pending state,
            // which is holder variable for state.
            // Real state is change when fade in is complete.
            // Change only if state is not same.
            if (pendingState != state)
            {
                fadeAnimation.FadeIn(true);
                pendingState = state;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Called when animation is fully faded in.
        /// </summary>
        private void fadeAnimation_OnFadedIn(object sender, EventArgs args)
        {
            // Fade animation is completed
            // so notify subscribers
            // and change state
            StateChanged(pendingState, GameState);
            GameState = pendingState;
            fadeAnimation.FadeOut(true);
        }

        /// <summary>
        /// Notifies subscribers.
        /// </summary>
        private void StateChanged(State newState, State oldState)
        {
            if(OnStateChange != null)
            {
                OnStateChange(this, new StateChangeEventArgs(newState, oldState));
            }
        }

        #endregion
    }
}

using Microsoft.Xna.Framework;
using ShooterGame.GameObjects.SpriteObjects;
using ShooterGame.GameObjects.SpriteObjects.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShooterGame.Utilities;

namespace ShooterGame.GameState.States
{
    /// <summary>
    /// Represents inital state of game.
    /// </summary>
    public class IntroState : BaseState
    {
        #region Fields

        private StateManager stateManager;
        private FadeAnimation fadeAnimation;
        private SpriteObject logo;
        private bool playIntro;
        private bool isAtMiddlePosition;
        private float goFromMiddlePositionWhenLengthIsLessThen = 500f;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors.
        /// </summary>
        /// <param name="game">Game reference.</param>
        public IntroState(Game1 game)
            : base(game) { }

        #endregion

        #region Methods

        /// <summary>
        /// Updates intro state logic.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if (!Active) return;

            if (stateManager.GameState != State.Intro_State
                && Active)
            {
                EndState(true);
                return;
            }

            // Logo should go from right to middle
            // and then from middle to left.
            if (playIntro)
            {
                // Find middle position and update logo position.
                Vector2 middlePos = new Vector2(Game.Window.ClientBounds.Width * .5f, Game.Window.ClientBounds.Height * .5f);
                if (!isAtMiddlePosition) logo.Position = Helper.EaseIn(logo.Position, middlePos, .2f);

                float length = logo.Position.LengthSquared() - middlePos.LengthSquared();
                if (length < goFromMiddlePositionWhenLengthIsLessThen) isAtMiddlePosition = true;

                // When add middle position go left and change state.
                if (isAtMiddlePosition)
                {
                    Vector2 endPosition = logo.Position;
                    endPosition.X = -(Game.Window.ClientBounds.Width + Game.Loader.LogoTexture.Width);

                    logo.Position = Helper.EaseOut(logo.Position, endPosition, 0.005f);
                    stateManager.ChangeState(State.Main_Menu_State);
                }


            }
        }

        /// <summary>
        /// Called when state is created.
        /// </summary>
        public override void Initalize()
        {
            // add fade animation and state manager
            fadeAnimation = new FadeAnimation(Game, Game.Loader.PixelTexture);
            fadeAnimation.Color = Color.Black;
            Game.GameObjects.AddGameObject(fadeAnimation);
            stateManager = StateManager.Instance;
            stateManager.FadeAnimation = fadeAnimation;

            // add logo, logo is on right side of screen at start position.
            logo = new SpriteObject(Game, Game.Loader.LogoTexture,
                new Vector2(Game.Window.ClientBounds.Width + Game.Loader.LogoTexture.Width, Game.Window.ClientBounds.Height * .5f))
                {
                    LayerDepth = .1f
                };
            Game.GameObjects.AddGameObject(logo);

            StartIntro();
        }

        /// <summary>
        /// Ends intro and gets rid of resources, and create new state.
        /// </summary>
        public override void EndState()
        {
            if (fadeAnimation != null)
            {
                Game.GameObjects.RemoveGameObject(fadeAnimation);
                fadeAnimation = null;
            }

            if (logo != null)
            {
                Game.GameObjects.RemoveGameObject(logo);
                logo = null;
            }

            if (Game.MainMenuState == null)
            {
                Game.MainMenuState = new MainMenuState(Game);
                Game.MainMenuState.Initalize();
            }
        }
 
        /// <summary>
        /// Ends intro and gets rid of resources, and create new state.
        /// </summary>
        /// <param name="deactivateState">Should we remain active ?</param>
        public void EndState(bool remainActive)
        {
            EndState();
            Active = remainActive;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Starts intro animation.
        /// </summary>
        private void StartIntro()
        {
            fadeAnimation.Fade = 1.0f;
            playIntro = true;
        }

        #endregion
    }

}

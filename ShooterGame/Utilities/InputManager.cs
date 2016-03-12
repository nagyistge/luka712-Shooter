using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.Utilities
{
    /// <summary>
    /// Input manager.
    /// </summary>
    public class InputManager
    {
        #region Fields

        private static KeyboardState currentKeyboardState;
        private static KeyboardState previousKeyboardState;

        private static GamePadState currentGamepadState;
        private static GamePadState previousGamepadState;

        #endregion

        #region Methods

        /// <summary>
        /// Updates input state manager.
        /// </summary>
        public static void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            previousGamepadState = currentGamepadState;
            currentGamepadState = GamePad.GetState(PlayerIndex.One);
        }

        /// <summary>
        /// Checks if key is pressed.
        /// </summary>
        public static bool KeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Check for single key press.
        /// </summary>
        public static bool KeyPress(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// Check if button is pressed.
        /// </summary>
        public static bool PadPressed(Buttons button)
        {
            return currentGamepadState.IsButtonDown(button);
        }

        /// <summary>
        /// Check for single press.
        /// </summary>
        public static bool PadPress(Buttons button)
        {
            return currentGamepadState.IsButtonDown(button) && previousGamepadState.IsButtonUp(button);
        }

        #endregion

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Common;
using ShooterGame.GameObjects.SpriteObjects.Animations;
using ShooterGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.SpriteObjects.Player
{
    public class Player : SpriteObject
    {
        #region Fields

        private readonly SpriteAnimation _spriteAnimation;
        private Vector2 position;
        private Index _index;
        private bool usePad;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs player.
        /// </summary>
        /// <param name="game">Game ref</param>
        /// <param name="texture">Texture</param>
        /// <param name="spriteAnimation">Sprite animation</param>
        /// <param name="position">Position</param>
        public Player(Game1 game, Texture2D texture, SpriteAnimation spriteAnimation, Vector2 position, float speed, Index playerIndex)
            :base(game, texture, position)
        {
            if (spriteAnimation == null)
            {
                throw new ArgumentNullException("spriteAnimation");
            }

            _spriteAnimation = spriteAnimation;
            _spriteAnimation.Position = position;
            Speed = speed;
            _index = playerIndex;
            usePad = _index == Index.Two;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets position.
        /// </summary>
        public override Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Rotates player, by actually rotating animation.
        /// </summary>
        public override float Rotation
        {
            get { return _spriteAnimation.Rotation; }
            set { _spriteAnimation.Rotation = value; }
        }

        /// <summary>
        /// Gets or sets speed.
        /// </summary>
        public float Speed { get; set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// Updates player
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            ClampPlayer();
            _spriteAnimation.Position = position;
            _spriteAnimation.Update(gameTime);
            MovePlayer(gameTime);
        }

        /// <summary>
        /// Draws player
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;

            _spriteAnimation.Draw(spriteBatch);
        }

        public void UseGamepad()
        {
            if(_index == Index.One)
            {
                PlayerSwitch.SetGamepad(Index.One, true);
                if(PlayerSwitch.Player1.Gamepad)
                {
                    usePad = true;
                }
                else
                {
                    usePad = false;
                }

            }
            else
            {
                PlayerSwitch.SetGamepad(Index.Two, true);
                if(PlayerSwitch.Player2.Gamepad)
                {
                    usePad = true;
                }
                else
                {
                    usePad = false;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Player movement
        /// </summary>
        private void MovePlayer(GameTime gameTime)
        {
            if((InputManager.KeyPressed(Keys.A) && !usePad)
                || (InputManager.PadPressed(Buttons.LeftThumbstickLeft | Buttons.DPadLeft) && usePad))
            {
                position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else if((InputManager.KeyPressed(Keys.D) && !usePad)
                 || (InputManager.PadPressed(Buttons.RightThumbstickRight | Buttons.DPadRight) && usePad))
            {
                position.X += Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            if((InputManager.KeyPressed(Keys.W) && !usePad)
                 || (InputManager.PadPressed(Buttons.LeftThumbstickUp | Buttons.DPadUp) && usePad))
            {
                position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else if((InputManager.KeyPressed(Keys.S) && !usePad)
                 || (InputManager.PadPressed(Buttons.LeftThumbstickDown | Buttons.DPadDown) && usePad))
            {
                position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            
        }

        /// <summary>
        /// Clamps player to screen.
        /// </summary>
        private void ClampPlayer()
        {
            position.X = MathHelper.Clamp(position.X , 0, Game.Window.ClientBounds.Width ); 
            position.Y = MathHelper.Clamp(position.Y, 0, Game.Window.ClientBounds.Height );
        }

        #endregion


    }
}

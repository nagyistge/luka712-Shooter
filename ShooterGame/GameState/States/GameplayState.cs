using Microsoft.Xna.Framework;
using ShooterGame.Common;
using ShooterGame.GameObjects;
using ShooterGame.GameObjects.SpriteObjects;
using ShooterGame.GameObjects.SpriteObjects.Animations;
using ShooterGame.GameObjects.SpriteObjects.Background;
using ShooterGame.GameObjects.SpriteObjects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameState.States
{
    public class GameplayState : BaseState
    {
        #region Fields

        private MovingBackground[] backgrounds;
        private Player player1;
        private Player player2;
        private ParticleEngine particleEngine;

        #endregion


        public GameplayState(Game1 game)
            : base(game)
        {

        }

        /// <summary>
        /// Initialize gameplay state.
        /// </summary>
        public override void Initalize()
        {
            #region Initialize backgrounds

            backgrounds = new MovingBackground[6];
            backgrounds[0] = new MovingBackground(this.Game,
                Game.Loader.MainBackground,
               Game.Window.ClientBounds, -Vector2.UnitX, Game.Settings.BackgroundSpeed[0]);
            backgrounds[0].LayerDepth = 0.001f;
            Game.GameObjects.Add(backgrounds[0]);

            backgrounds[1] = new MovingBackground(Game,
                Game.Loader.BackgroundLayer1,
               Game.Window.ClientBounds,
                    -Vector2.UnitX, Game.Settings.BackgroundSpeed[1]);
            backgrounds[1].LayerDepth = 0.002f;
            Game.GameObjects.Add(backgrounds[1]);

            backgrounds[2] = new MovingBackground(Game,
                Game.Loader.BackgroundLayer2,
               Game.Window.ClientBounds,
                -Vector2.UnitX, Game.Settings.BackgroundSpeed[2]);
            backgrounds[2].LayerDepth = 0.003f;
            Game.GameObjects.Add(backgrounds[2]);

            Rectangle movedRect = new Rectangle(Game.Window.ClientBounds.Width, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

            backgrounds[3] = (MovingBackground)backgrounds[0].Clone();
            backgrounds[3].DrawRectangle = movedRect;
            Game.GameObjects.Add(backgrounds[3]);

            backgrounds[4] = (MovingBackground)backgrounds[1].Clone();
            backgrounds[4].DrawRectangle = movedRect;
            Game.GameObjects.Add(backgrounds[4]);

            backgrounds[5] = (MovingBackground)backgrounds[2].Clone();
            backgrounds[5].DrawRectangle = movedRect;
            Game.GameObjects.Add(backgrounds[5]);
                		 
	        #endregion

            #region Initalize player ships 

            player1 = new Player(Game, Game.Loader.Player1Texture,
                new SpriteAnimation(Game, Game.Loader.Player1Texture, new Vector2(100, 100), new Vector2(64, 64), 8) { LayerDepth = 0.005f }
                , new Vector2(100, 100), Game.Settings.PlayerSpeed, Index.One) { Rotation = (float)Math.PI * .5f };
            Game.GameObjects.Add(player1);

            player2 = new Player(Game, Game.Loader.Player2Texture,
                new SpriteAnimation(Game, Game.Loader.Player2Texture, new Vector2(300, 100), new Vector2(64, 64), 5) { LayerDepth = 0.005f }, new Vector2(300, 100), Game.Settings.PlayerSpeed, Index.Two) { Rotation = (float)Math.PI * .5f };
            Game.GameObjects.Add(player2);

            // Leave particle engine for last, internally particle engine sorts game objects.
            particleEngine = new ParticleEngine(Game);
            Game.GameObjects.Add(particleEngine);

            #endregion
        }

        /// <summary>
        /// Ends gameplay state.
        /// </summary>
        public override void EndState()
        {
            throw new NotImplementedException();
        }
    }
}

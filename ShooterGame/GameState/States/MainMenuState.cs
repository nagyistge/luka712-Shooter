using Microsoft.Xna.Framework;
using ShooterGame.Common;
using ShooterGame.GameObjects;
using ShooterGame.GameObjects.FontObjects.Controls;
using ShooterGame.GameObjects.FontObjects.DelegatesAndEvents;
using ShooterGame.GameObjects.SpriteObjects.Background;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameState.States
{
    /// <summary>
    /// Main menu state.
    /// </summary>
    public class MainMenuState : BaseState
    {
        #region Fields

        private Dictionary<string, State> mainMenu;
        private MovingBackground[] backgrounds;
        private MenuControl menu;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="game">Game reference.</param>
        public MainMenuState(Game1 game)
            : base(game) { }

        #endregion

        #region Properties

        public Dictionary<string, State> MainMenu
        {
            get
            {
                if(mainMenu == null)
                {
                    mainMenu =  new Dictionary<string,State>()
                        { 
                            { "New Game", State.Game_State },
                            { "Options", State.Options_State },
                            { "High Scores", State.High_Scores_State }, 
                            { "Credits", State.Credits_State }, 
                            { "Quit Game", State.Quit_Game_State } 
                        };
                }
                return mainMenu;
            }
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Initializes state for main menu.
        /// </summary>
        public override void Initalize()
        {
            // Create background if null
            if(backgrounds == null)
            {
                backgrounds = new MovingBackground[3];
                backgrounds[0] = new MovingBackground(this.Game,
                    Game.Loader.MainBackground,
                   Game.Window.ClientBounds, Vector2.Zero, 0f);
                backgrounds[0].LayerDepth = 0.001f;
                Game.GameObjects.Add(backgrounds[0]);

                backgrounds[1] = new MovingBackground(Game,
                    Game.Loader.BackgroundLayer1,
                   Game.Window.ClientBounds,
                        Vector2.Zero, 0f);
                backgrounds[1].LayerDepth = 0.002f;
                Game.GameObjects.Add(backgrounds[1]);

                backgrounds[2] = new MovingBackground(Game,
                    Game.Loader.BackgroundLayer2,
                   Game.Window.ClientBounds,
                    Vector2.Zero, 0f);
                backgrounds[2].LayerDepth = 0.003f;
                Game.GameObjects.AddGameObject(backgrounds[2]);
            }
            else
            {
                foreach(MovingBackground background in backgrounds)
                {
                    background.Active = true;
                }
            }

            // If null create new , else activate it.
            if (menu == null)
            {
                menu = new MenuControl(Game, Game.Loader.GameFont,
                    TextAlignment.Vertical,
                         HorizontalAlignment.Center,
                    VerticalAlignment.Center,
                    MainMenu.Keys.ToArray());
                menu.OnMenuSelection += MenuSelection;
                menu.LayerDepth = 0.99f;
                Game.GameObjects.AddGameObject(menu);
            }
            else
            {
                menu.Active = true;
            }

        }

        /// <summary>
        /// Release resources.
        /// </summary>
        public override void EndState()
        {
            if (menu != null) menu.Active = false;
            foreach (MovingBackground b in backgrounds) b.Active = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// On menu selection.
        /// </summary>
        private void MenuSelection(object sender, MenuControlEventArgs args)
        {
            StateManager.Instance.ChangeState(MainMenu[args.MenuSelectionInfo]);

            switch(args.MenuSelectionInfo)
            {
                case "New Game":
                    if (Game.GameplayState == null)
                    {
                        Game.GameplayState = new GameplayState(Game);
                    }
                    // Subscribe and unsubscribe once initialization is done.
                    OnFadedIn stateChange = null;
                    stateChange = (s, e) =>
                    {
                        EndState();
                        Game.GameplayState.Initalize();
                        StateManager.Instance.FadeAnimation.OnFadedIn -= stateChange;
                    };
                    StateManager.Instance.FadeAnimation.OnFadedIn += stateChange;
                    break;
            }
        }


        #endregion

    }
}

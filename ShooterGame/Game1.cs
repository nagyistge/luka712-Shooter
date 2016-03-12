using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.GameObjects;
using ShooterGame.GameObjects.FontObjects;
using ShooterGame.GameObjects.SpriteObjects;
using ShooterGame.GameObjects.SpriteObjects.Animations;
using ShooterGame.GameState;
using ShooterGame.GameState.States;
using ShooterGame.Utilities;
using ShooterGame.Utilities.Implementation;
using ShooterGame.Utilities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShooterGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public partial class Game1 : Game
    {
        #region Fields

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private GameObject[] _gameObjects;
        private int totalCount;

        #endregion

        #region Constructors

        public Game1(ILoader loader, ISettings settings, ISpawnTimes spawnTimes)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Loader = loader;
            Settings = settings;
            SpawnTimes = spawnTimes;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;

            _gameObjects = new GameObject[0];
            GameObjects = new GameObjectList<GameObject>();
            GameObjects.OnAddOrRemove += GameObjects_OnAdd;

            IntroState = new IntroState(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of all game objects.
        /// </summary>
        public IGameObjectList<GameObject> GameObjects { get; private set; }

        /// <summary>
        /// Holds all game resources.
        /// </summary>
        public ILoader Loader { get; private set; }

        /// <summary>
        /// Game spawn times.
        /// </summary>
        public ISpawnTimes SpawnTimes { get; private set; }

        /// <summary>
        /// Holds all game settngs... Globals
        /// </summary>
        public ISettings Settings { get; private set; }

        /// <summary>
        /// Gets or sets intro state
        /// </summary>
        public IntroState IntroState { get; set; }

        /// <summary>
        /// Main Menu state
        /// </summary>
        public MainMenuState MainMenuState { get; set; }

        /// <summary>
        /// Gameplay state
        /// </summary>
        public GameplayState GameplayState { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Loader.Load(Content, GraphicsDevice);
            InitalizeGame();
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputManager.Update();
            IntroState.Update(gameTime);
            

            int i = 0;
            for (; i < totalCount; i++)
            {
                _gameObjects[i].Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            int i = 0;
            for (; i < totalCount; i++)
            {
                _gameObjects[i].Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initalizes new game.
        /// </summary>
        private void InitalizeGame()
        {
            IntroState.Initalize();
        }

        /// <summary>
        /// Raised when object is added to list.
        /// </summary>
        private void GameObjects_OnAdd(object sender, EventArgs e)
        {
            totalCount = GameObjects.Count;
            _gameObjects = new GameObject[totalCount];

            // Sort before copying.
            GameObjects.OrderBy(x => x.GetType());
            GameObjects.Where(x => x is SpriteObject).OrderBy(x => ((SpriteObject)x).TextureName);

            // Copy objects.
            for (int i = 0; i < totalCount; i++)
            {
                _gameObjects[i] = GameObjects[i];
            }
        }

        #endregion

    }
}

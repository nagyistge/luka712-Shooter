using Microsoft.Xna.Framework;
using ShooterGame.GameObjects.SpriteObjects;
using ShooterGame.GameObjects.SpriteObjects.Particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects
{
    /// <summary>
    /// Particle engine.
    /// </summary>
    public class ParticleEngine : GameObject
    {
        #region Fields

        private readonly Rectangle _clientBounds;
        private readonly Random _random;

        private const int SNOW_PARTICLES_COUNT = 100;
        private readonly SimpleParticle[] _snowParticles;
        private float snowParticleSpawnTimer = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public ParticleEngine(Game1 game)
            : base()
        {
            Game = game;
            _clientBounds = Game.Window.ClientBounds;
            _random = new Random();
            Game.GameObjects.Add(this);
            _snowParticles = SnowSprites(SNOW_PARTICLES_COUNT).ToArray();
            game.GameObjects.AddGameObjectRange(_snowParticles);
        }

        #endregion

        #region Methods

        public override void Update(GameTime gameTime)
        {
            RespawnSnowParticle(gameTime);
            UpdateSnowParticles();
        }

        public override void ResetObject()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create snow particles pool.
        /// </summary>
        private List<SimpleParticle> SnowSprites(int count)
        {
            List<SimpleParticle> result = new List<SimpleParticle>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new SimpleParticle(Game, Game.Loader.SnowTexture) { LayerDepth = 0.004f });
            }

            return result;
        }

        private void UpdateSnowParticles()
        {
            for (int i = 0; i < SNOW_PARTICLES_COUNT; i++)
            {
                if (!_snowParticles[i].Active) return;

                // Check if particle is out of bound, if so deactivate it.
                float height = Game.Loader.SnowTexture.Height * _snowParticles[i].Scale;
                bool yIsOutOfBound = _snowParticles[i].Position.Y > _clientBounds.Height + height;
                if (_snowParticles[i].Position.X < 0 || yIsOutOfBound)
                {
                    _snowParticles[i].Active = false;
                }
            }
        }

        /// <summary>
        /// Respawns particles.
        /// </summary>
        private void RespawnSnowParticle(GameTime gameTime)
        {
            snowParticleSpawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (snowParticleSpawnTimer > Game.SpawnTimes.SnowParticleSpawnTime)
            {
                // reset timer.
                snowParticleSpawnTimer = 0f;

                SimpleParticle particle = _snowParticles.Where(x => !x.Active).FirstOrDefault();
                if (particle != null)
                {
                    particle.Active = true;
                    particle.Position = new Vector2(_random.Next(0, _clientBounds.Width + 200), -Game.Loader.SnowTexture.Height);
                    Vector2 direction = Vector2.Zero;
                    do
                    {
                        direction = new Vector2(-(float)_random.NextDouble(), (float)_random.NextDouble());
                    } while (direction == Vector2.Zero);
                    particle.Direction = direction;
                   
                    particle.Scale = (float)_random.NextDouble();

                    float speed;
                    do
                    {
                        speed = (float)_random.NextDouble();
                    } while (speed < 0.3f);
                    particle.Speed = speed * .5f + Game.Settings.SnowSpeed;
                }
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Windows_XNA_Tanks.Model;
using Windows_XNA_Tanks.Model.Tiles;
using System.IO;
using Windows_XNA_Tanks.Process;
using Windows_XNA_Tanks_Map_Builder;
using Windows_XNA_Tanks.Model.Turrets;

namespace Windows_XNA_Tanks
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TankGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        Parser parser;
        Player vermeulengbeast;
        Computer vermeulengbeastAI;
        Bullet bullet;
        List<Tank> ingameTanks;

        private const int TILE_SIZE= 32;

        // Tiles - Background
        public Texture2D grassImage, streetImage, wallImage, bulletImage;

        // Tank
        private Texture2D tankImage, bodyImage, turretImage;

       
        public TankGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

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
            
            parser = new Parser(this);
            
            // Loading map
            map = parser.LoadMap(1);
            graphics.PreferredBackBufferHeight = map.Height * TILE_SIZE;
            graphics.PreferredBackBufferWidth = map.Width * TILE_SIZE;
            graphics.ApplyChanges();

            // Creating a Player + his adding a tank to his tanks + chosing the tank he wil use + giving him his position
            vermeulengbeast = new Player();
            vermeulengbeast.addTanktoPlayersTanks(new Tank(bodyImage, bulletImage, map));
            vermeulengbeast.UsedTank = vermeulengbeast.tanks[0];
            vermeulengbeast.UsedTank.createVectorAndRectangle(map.startPoints[0]);

            vermeulengbeast.tanks[0].MainGun = new StandaardTurret(vermeulengbeast.tanks[0], turretImage);

            // Computer
            vermeulengbeastAI = new Computer();
            vermeulengbeastAI.Tank = new Tank(tankImage, bulletImage, map);
            vermeulengbeastAI.Tank.createVectorAndRectangle(map.startPoints[1]);

            ingameTanks = new List<Tank>();
            ingameTanks.Add(vermeulengbeast.UsedTank);
            ingameTanks.Add(vermeulengbeastAI.Tank);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Tiles - Background
            grassImage = Content.Load<Texture2D>("Tiles/grass");
            streetImage = Content.Load<Texture2D>("Tiles/street");
            wallImage = Content.Load<Texture2D>("Tiles/wall");

            // Entities
            tankImage = Content.Load<Texture2D>("Entity/tank");
            bodyImage = Content.Load<Texture2D>("Entity/body");
            turretImage = Content.Load<Texture2D>("Entity/turret");
            bulletImage = Content.Load<Texture2D>("Entity/bullet");

            //using (MapBuilder mapBuilder = new MapBuilder(20, 20))
            //{
            //   mapBuilder.Run();
            //}

           

            
            //sprite.loadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            vermeulengbeast.Update();
            vermeulengbeast.UsedTank.Update();

            // Computer
            vermeulengbeastAI.AimToClosestTank(ingameTanks);
            vermeulengbeastAI.Tank.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            map.Drawmap(spriteBatch);
            vermeulengbeast.UsedTank.Draw(spriteBatch);
            vermeulengbeastAI.Tank.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}

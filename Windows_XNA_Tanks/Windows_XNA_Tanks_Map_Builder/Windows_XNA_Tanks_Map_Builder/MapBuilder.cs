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
using Windows_XNA_Tanks_Map_Builder.Model;

namespace Windows_XNA_Tanks_Map_Builder
{
    public class MapBuilder : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private int x;
        private int y;
        private Grid grid;
        private List<Texture2D> textures;
        private Texture2D selectedTexture;
        private MouseState mouseState;
        private const int TILE_SIZE = 32;

        public MapBuilder(int x, int y)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.x = x;
            this.y = y;
        }

        protected override void Initialize()
        {
            Window.Title = "XNA tanks map builder - Press F5 to save the map.";
            IsMouseVisible = true;
            grid = new Grid(x, y, Content);
            CreateTextures();
            selectedTexture = textures.FirstOrDefault();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CalculateScreenSize();
        }

        private void CalculateScreenSize()
        {
            graphics.PreferredBackBufferHeight = y * TILE_SIZE;
            graphics.PreferredBackBufferWidth = (x * TILE_SIZE) + 64;
            graphics.ApplyChanges();
        }

        private void CreateTextures()
        {
            textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("Tiles/grass"));
            textures.Add(Content.Load<Texture2D>("Tiles/street"));
            textures.Add(Content.Load<Texture2D>("Tiles/wall"));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            SelectTexture();
            CheckMouseOnGrid();

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.F5))
            {
                var jaja = 0;
            }


            base.Update(gameTime);
        }

        private void SelectTexture()
        {
            int index = 1;
            mouseState = Mouse.GetState();
            foreach (Texture2D texture in textures)
            {
                if (mouseState.X >= (x * TILE_SIZE + 16) && mouseState.X <= (x * TILE_SIZE + 48))
                {
                    if (mouseState.Y >= (index * 40) && mouseState.Y <= (index * 40) + TILE_SIZE)
                    {
                        if (mouseState.LeftButton == ButtonState.Pressed)
                            selectedTexture = texture;
                    }
                }
                index++;
            }
        }

        private void CheckMouseOnGrid()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    mouseState = Mouse.GetState();
                    if ((int)Math.Ceiling((decimal)mouseState.X / TILE_SIZE) - 1 == i && (int)Math.Ceiling((decimal)mouseState.Y / TILE_SIZE) - 1 == j && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        grid.Tiles[i, j] = selectedTexture;
                        return;
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            grid.Draw(spriteBatch, TILE_SIZE);
            int index = 0;
            foreach (Texture2D texture in textures)
            {
                spriteBatch.Draw(texture, new Rectangle((x * TILE_SIZE) + 16, TILE_SIZE + (index * 40), TILE_SIZE, TILE_SIZE), Color.White);
                index++;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

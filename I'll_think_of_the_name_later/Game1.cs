using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Illthinkofthenamelater
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;       
        Camera cam = new Camera();
 

        Player m_player;

        //sup sluz
        //oh sweet as slus cus gg no re big d sea hk your gay
        public const int screenSizeX = 1280;
        public const int screenSizeY = 720;

        private Vector2 cursorPos;
        private Vector2 drawCursor;
        

        //Textures_Start

        //Player sprite
        Texture2D playerTex;
        Texture2D bulletTex;
        Texture2D crosshairTex;
        Texture2D background;
            
        //Textures_End

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = screenSizeX;
            graphics.PreferredBackBufferHeight = screenSizeY;
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTex = Content.Load<Texture2D>("player.png");
            bulletTex = Content.Load<Texture2D>("bulletTest");
            crosshairTex = Content.Load<Texture2D>("crosshair1");
            background = Content.Load<Texture2D>("$MAP_PlaceTogether");

            m_player = new Player(new Vector2(80, 80), new Vector2(playerTex.Width, playerTex.Height), 10f, 10, playerTex, 30, 2, bulletTex,
                                    Color.White);
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

            m_player.Update(gameTime);
    
            cursorPos = new Vector2(Mouse.GetState().X - 24, Mouse.GetState().Y - 16);

            float relativeMouseX = cursorPos.X + cam._pos.X;
            float relativeMouseY = cursorPos.Y + cam._pos.Y;

            drawCursor = new Vector2(relativeMouseX, relativeMouseY);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            cam.Pos = new Vector2((float)m_player.GetPlayerPos().X, (float)m_player.GetPlayerPos().Y);

            spriteBatch.Begin(SpriteSortMode.BackToFront,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        cam.get_transformation(GraphicsDevice));

            spriteBatch.Draw(crosshairTex, drawCursor, Color.White);

            m_player.Draw(spriteBatch);

            spriteBatch.Draw(background, new Rectangle(0, 0, screenSizeX, screenSizeY), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

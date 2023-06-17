using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Vantuz
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Stage currentStage;
        private Stage nextStage;
        public Texture2D buttonTexture;
        public SpriteFont buttonFont;
        public int buttonWidth = 200;
        public int buttonHeight = 75;
        public int soundButtonSize = 50;
        public Vector2 soundButtonPosition;
        public int Score;
        public int Prize = 33;
        public Texture2D skipTexture;
        public Texture2D Table;
        public Texture2D Sound;
        public List<string> WinText;
        public List<string> LoseText;
        public Vector2 CurrentPosition = new Vector2(0, 500);
        public bool PlayerInHallway { get; set; }
        public Button BackToHallway;
        public Button Skip;
        public Button Next;
        public Button StartGame;
        public bool IsMusicOn = true;
        public Song Song { get; set; }
        private Button Music;
        public Texture2D MenuBackground;

        public void ChangeStage(Stage stage)
        {
            nextStage = stage;
        }
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            buttonTexture = Content.Load<Texture2D>("button_gold");
            buttonFont = Content.Load<SpriteFont>("Font");
            currentStage = new MenuStage(this, graphics.GraphicsDevice, Content);
            skipTexture = Content.Load<Texture2D>("right-arrow");
            Table = Content.Load<Texture2D>("field");
            Sound = Content.Load<Texture2D>("sound");
            soundButtonPosition = new Vector2(1200, 20);
            WinText = File.ReadLines("Win.txt").ToList();
            LoseText = File.ReadLines("Lose.txt").ToList();
            MenuBackground = Content.Load<Texture2D>("State");
            MediaPlayer.Play(Song);
            MediaPlayer.IsRepeating = true;

            BackToHallway = new Button(buttonTexture,buttonFont)
            {
                Position = new Vector2(10, 10),
                Width = buttonWidth,
                Height = buttonHeight,
                Text = "НАЗАД",
            };

            Next = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(540, 450),
                Width = buttonWidth,
                Height = buttonHeight,
                Text = "ДАЛЬШЕ",
            };

            Skip = new Button(skipTexture, buttonFont)
            {
                Position = new Vector2(900, 600),
                Width = 50,
                Height = 50,
            };

            StartGame = new Button(Table, buttonFont)
            {
                Position = new Vector2(520, 550),
                Width = buttonWidth,
                Height = buttonHeight,
                Text = "ПОМОЧЬ",
            };

            Music = new Button(Sound, buttonFont)
            {
                Position = soundButtonPosition,
                Width = soundButtonSize,
                Height = soundButtonSize,
            };

            Music.Click += Music_Click;
        }

        private void Music_Click(object sender, EventArgs e)
        {
            if (IsMusicOn)
            {
                MediaPlayer.Stop();
                IsMusicOn = false;
            }
            else
            {
                MediaPlayer.Play(Song);
                IsMusicOn = true;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (nextStage != null)
            {
                currentStage = nextStage;
                nextStage = null;
            }

            currentStage.Update(gameTime);
            Music.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            currentStage.Draw(gameTime, spriteBatch);
            Music.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
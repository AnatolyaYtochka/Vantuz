using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Vantuz
{ 
    public class DialogRoom: Stage
    {
        private readonly Button BackToHallway;
        private readonly Button Skip;
        private readonly Button StartGame;
        private readonly List<Button> skip;
        private bool IsPressed = false;
        public static bool IsNeedToStartGame;

        private readonly Texture2D gameOverPicture;
        private readonly Song gameOverMusic;
        private readonly string gameOverText;
        public static Texture2D Background { get; set; }
        public static Stage MiniGameStage { get; set; }
        public static Texture2D Person { get; set; }
        public static List<string> Lines { get; set; }

        public DialogRoom(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            if (Game.IsMusicOn) MediaPlayer.Play(Game.Song);
            gameOverMusic = content.Load<Song>("GameOverMusic");
            gameOverPicture = content.Load<Texture2D>("GameOverPicture");
            gameOverText = "Поздравляю, вы победили)";
            BackToHallway = Game.BackToHallway;
            Skip = Game.Skip;
            StartGame = Game.StartGame;
            BackToHallway.Click += BackToHallway_Click;
            Skip.Click += Skip_Click;
            StartGame.Click += StartGame_Click;
            skip = new List<Button> { Skip };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Rectangle(0, 0, 1280, 720), Color.DarkGray);
            BackToHallway.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(Person, new Rectangle(400, 125, 400, 700), Color.White);
            spriteBatch.Draw(Game.Table, new Rectangle(200, 500, 840, 200), Color.White);

            foreach (var i in skip)
                i.Draw(gameTime, spriteBatch);

            if (Lines.Count > 0)
            {
                spriteBatch.DrawString(Game.buttonFont, Lines[0], new Vector2(300, 550), Color.Black);
                if (IsPressed)
                {
                    Lines.Remove(Lines[0]);
                    IsPressed = false;
                }
            }
            else
            {
                skip.Remove(Skip);
                if (IsNeedToStartGame) StartGame.Draw(gameTime, spriteBatch);
                if (GameStage.IsGameOver)
                {
                    CloseDoor.Background = gameOverPicture;
                    Game.Song = gameOverMusic;
                    CloseDoor.Text = gameOverText;
                    Game.ChangeStage(new CloseDoor(Game, GraphicsDevice, ContentManager));
                }
            }

        }

        public override void Update(GameTime gameTime)
        {
            BackToHallway.Update(gameTime);  
            Skip.Update(gameTime);
            if (IsNeedToStartGame) StartGame.Update(gameTime);
        }

        private void BackToHallway_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(new GameStage(Game, GraphicsDevice, ContentManager));
        }

        private void Skip_Click(object sender, EventArgs e)
        {
            IsPressed = true;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(MiniGameStage);
        }
    }
}

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;

namespace Vantuz
{
    public class CloseDoor : Stage
    {
        private readonly Button OK_Button;
        public static string Text { get; set; }
        public static Texture2D Background { get; set; }

        public CloseDoor(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            if (Game.IsMusicOn) MediaPlayer.Play(Game.Song);

            OK_Button = new Button(Game.Table, Game.buttonFont)
            {
                Position = new Vector2(550, 300),
                Width = Game.buttonWidth,
                Height = Game.buttonHeight,
                Text = "ОК",
            };

            OK_Button.Click += BackToHallway_Click;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Rectangle(0, 0, 1280, 720), Color.DarkGray);
            spriteBatch.Draw(Game.Table, new Rectangle(450, 200, 410, 200), Color.LightYellow);
            spriteBatch.DrawString(Game.buttonFont, Text, new Vector2(515, 250), Color.Brown);
            OK_Button.Draw(gameTime, spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            OK_Button.Update(gameTime);
        }

        private void BackToHallway_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(new GameStage(Game, GraphicsDevice, ContentManager));
            if (GameStage.IsGameOver)
            {
                GameStage.IsGiven_MathGame = false;
                GameStage.IsGiven_ArchitectureGame = false;
                GameStage.IsGiven_EconomicGame = false;
                GameStage.IsGameOver = false;
                GameStage.IsPlayerHavePaperBill = false;
                Game.Score = 0;
                Game.CurrentPosition = new Vector2(0, 500);
                Game.ChangeStage(new MenuStage(Game, GraphicsDevice, ContentManager));
            }
        }
    }
}

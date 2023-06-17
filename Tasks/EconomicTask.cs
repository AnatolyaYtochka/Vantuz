using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Vantuz
{
    public class EconomicTask : Stage
    {
        private readonly Texture2D background;
        private readonly Button BackToHallway;
        private readonly List<Button> alphabet;
        private readonly List<char> text;
        private readonly List<Texture2D> lives;
        private readonly Button Next;
        private bool IsLose = false;
        private bool IsWin = false;

        public EconomicTask(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            background = content.Load<Texture2D>("room1");
            var heart = content.Load<Texture2D>("heart");
            var letterTexture = content.Load<Texture2D>("full");
            alphabet =  new List<Button>();
            text = new List<char>();
            for (var i = 0; i < 6; i++)
                text.Add('_');
            lives = new List<Texture2D>();
            for (var i = 0; i < 3; i++)
                lives.Add(heart);
            BackToHallway = Game.BackToHallway;
            Next = Game.Next;
            var X = 260;
            var Y = 435;
            var count = 0;

            for (var i = 'А'; i <= 'Я'; i++)
            {
                count++;
                if (count == 23)
                {
                    X = 285;
                    Y = 585;
                }
                else if (count == 12)
                {
                    X = 260;
                    Y = 510;
                }
                var button = new Button(letterTexture, Game.buttonFont)
                {
                    Position = new Vector2(X, Y),
                    Width = 50,
                    Height = 50,
                    Text = i.ToString(),
                    PenColour = Color.Black,
                };
                if (i == 'Д') button.Click += Button_5_Click;
                else if (i == 'Е') button.Click += Button_6_Click;
                else if (i == 'Н') button.Click += Button_14_Click;
                else if (i == 'Ь') button.Click += Button_28_Click;
                else if (i == 'Г') button.Click += Button_4_Click;
                else if (i == 'И') button.Click += Button_9_Click;
                else button.Click += Button_Click;
                alphabet.Add(button);
                X += 75;
            }

            BackToHallway.Click += BackToHallway_Click;
            Next.Click += Next_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (lives.Count > 1) lives.RemoveAt(0);
            else IsLose = true;
        }

        private void Button_5_Click(object sender, EventArgs e)
        {
            text[0] = 'Д';
        }

        private void Button_6_Click(object sender, EventArgs e)
        {
            text[1] = 'Е';
        }

        private void Button_14_Click(object sender, EventArgs e)
        {
            text[2] = 'Н';
        }

        private void Button_28_Click(object sender, EventArgs e)
        {
            text[3] = 'Ь';
        }

        private void Button_4_Click(object sender, EventArgs e)
        {
            text[4] = 'Г';
        }

        private void Button_9_Click(object sender, EventArgs e)
        {
            text[5] = 'И';
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.DarkGray);
            BackToHallway.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(Game.Table, new Rectangle(175, 400, 990, 280), Color.LightYellow);
            spriteBatch.Draw(Game.Table, new Rectangle(300, 20, 700, 370), Color.LightYellow);
            spriteBatch.DrawString(Game.buttonFont, "Угадай, какое слово загадано:", new Vector2(480, 50), Color.Brown);

            foreach (var letter in alphabet)
                letter.Draw(gameTime, spriteBatch);

            var start = 500;
            foreach (var item in text)
            {
                spriteBatch.DrawString(Game.buttonFont, item.ToString(), new Vector2(start, 200), Color.Brown);
                start += 50;
            }

            var start_lives = 525;
            foreach (var live in lives)
            {
                spriteBatch.Draw(live, new Rectangle(start_lives, 300, 50, 50), Color.White);
                start_lives += 100;
            }

            if (IsWin)
            {
                spriteBatch.Draw(Game.Table, new Rectangle(350, 100, 600, 500), Color.LightYellow);
                var textPosition = 150;
                foreach (var i in Game.WinText)
                {
                    spriteBatch.DrawString(Game.buttonFont, i.ToUpper(), new Vector2(500, textPosition), Color.Brown);
                    textPosition += 50;
                }
                Next.Draw(gameTime, spriteBatch);
            }

            if (IsLose)
            {
                spriteBatch.Draw(Game.Table, new Rectangle(350, 100, 600, 500), Color.LightBlue);
                var textPosition = 200;
                foreach (var i in Game.LoseText)
                {
                    spriteBatch.DrawString(Game.buttonFont, i.ToUpper(), new Vector2(500, textPosition), Color.Black);
                    textPosition += 50;
                }
                Next.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            CheckWin();
            BackToHallway.Update(gameTime);
            if (IsWin || IsLose) Next.Update(gameTime);
            foreach (var letter in alphabet)
                letter.Update(gameTime);
        }

        private void BackToHallway_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(new GameStage(Game, GraphicsDevice, ContentManager));
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (IsWin)
            {
                Game.Score += Game.Prize;
                GameStage.IsGiven_EconomicGame = true;
                IsWin = false;
            }
            Game.ChangeStage(new GameStage(Game, GraphicsDevice, ContentManager));
        }

        private void CheckWin()
        {
            IsWin = !text.Contains('_');
        }
    }
}

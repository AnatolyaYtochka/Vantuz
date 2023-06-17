using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Vantuz
{
    public class MathTask : Stage
    {
        private readonly Texture2D Background;
        private readonly Texture2D Plus;
        private readonly Texture2D Minus;
        private readonly Texture2D Equally;
        private readonly Texture2D Peach;
        private readonly Texture2D Banana;
        private readonly Texture2D Apple;
        private readonly Texture2D Six;
        private readonly Texture2D Sixteen;
        private readonly Texture2D Twelve;
        private readonly Texture2D Question;
        private readonly int WidthNumber = 100;
        private readonly int HeightNumber = 100;
        private readonly int WidthOperation = 50;
        private readonly int HeightOperation = 50;
        private readonly Button BackToHallway;
        private readonly Button Next;
        private readonly List<Component> buttons;
        private bool IsWin = false;
        private bool IsGameFinish = false;

        public MathTask(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            Background = content.Load<Texture2D>("room107");
            Plus = content.Load<Texture2D>("plus");
            Minus = content.Load<Texture2D>("minus");
            Equally = content.Load<Texture2D>("equally");
            Six = content.Load<Texture2D>("six");
            Sixteen = content.Load<Texture2D>("sixteen");
            Twelve = content.Load<Texture2D>("twelve");
            Peach = content.Load<Texture2D>("peach");
            Banana = content.Load<Texture2D>("banana");
            Apple = content.Load<Texture2D>("apple");
            Question = content.Load<Texture2D>("question");
            BackToHallway = Game.BackToHallway;
            Next = Game.Next;

            var PeachButton = new Button(Peach, Game.buttonFont)
            {
                Position = new Vector2(75, 150),
                Width = WidthNumber,
                Height = HeightNumber,
            };

            var BananaButton = new Button(Banana, Game.buttonFont)
            {
                Position = new Vector2(75, 300),
                Width = WidthNumber,
                Height = HeightNumber,
            };

            var AppleButton = new Button(Apple, Game.buttonFont)
            {
                Position = new Vector2(75, 450),
                Width = WidthNumber,
                Height = HeightNumber,
            };

            BackToHallway.Click += BackToHallway_Click;
            Next.Click += Next_Click;
            PeachButton.Click += PeachButton_Click;
            BananaButton.Click += BananaButton_Click;
            AppleButton.Click += AppleButton_Click;
            buttons = new List<Component>() { PeachButton, BananaButton, AppleButton };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, new Rectangle(0, 0, 1280, 720), new Rectangle(0, 0, Background.Width, Background.Height), Color.DarkGray);
            BackToHallway.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(Game.Table, new Rectangle(200, 10, 1010, 700), Color.White);
            spriteBatch.Draw(Peach, new Rectangle(250, 75, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Plus, new Rectangle(400, 100, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Peach, new Rectangle(500, 75, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Plus, new Rectangle(650, 100, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Peach, new Rectangle(750, 75, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Equally, new Rectangle(900, 100, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Six, new Rectangle(1050, 75, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Banana, new Rectangle(250, 200, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Plus, new Rectangle(400, 225, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Banana, new Rectangle(500, 200, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Plus, new Rectangle(650, 225, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Peach, new Rectangle(750, 200, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Equally, new Rectangle(900, 225, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Twelve, new Rectangle(1050, 200, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Apple, new Rectangle(250, 325, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Plus, new Rectangle(400, 350, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Banana, new Rectangle(500, 325, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Plus, new Rectangle(650, 350, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Peach, new Rectangle(750, 325, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Equally, new Rectangle(900, 350, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Sixteen, new Rectangle(1050, 325, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Apple, new Rectangle(250, 450, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Minus, new Rectangle(400, 500, WidthOperation, HeightOperation / 3), Color.White);
            spriteBatch.Draw(Banana, new Rectangle(500, 450, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Minus, new Rectangle(650, 500, WidthOperation, HeightOperation / 3), Color.White);
            spriteBatch.Draw(Peach, new Rectangle(750, 450, WidthNumber, HeightNumber), Color.White);
            spriteBatch.Draw(Equally, new Rectangle(900, 475, WidthOperation, HeightOperation), Color.White);
            spriteBatch.Draw(Question, new Rectangle(1050, 450, WidthNumber, HeightNumber), Color.White);
            spriteBatch.DrawString(Game.buttonFont, "Какой фрукт должен стоять на месте вопроса?", new Vector2(450, 600), Color.Brown);
            spriteBatch.Draw(Game.Table, new Rectangle(50, 100, 150, 500), Color.White);

            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);

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

            if (IsGameFinish)
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
            BackToHallway.Update(gameTime);
            foreach (var button in buttons)
                button.Update(gameTime);
            if (IsWin || IsGameFinish) Next.Update(gameTime);
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
                GameStage.IsGiven_MathGame = true;
                IsWin = false;
            }
            Game.ChangeStage(new GameStage(Game, GraphicsDevice, ContentManager));
        }

        private void PeachButton_Click(object sender, EventArgs e)
        {
            IsWin = true;
        }

        private void BananaButton_Click(object sender, EventArgs e)
        {
            IsGameFinish = true;
        }

        private void AppleButton_Click(object sender, EventArgs e)
        {
            IsGameFinish = true;
        }
    }
}
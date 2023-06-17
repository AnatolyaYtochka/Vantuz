using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Vantuz
{
    public class ArchitectureTask : Stage
    {
        private List<Component> components;
        private Button centre;
        private Button BackToHallway;
        private Button Next;
        private Button pic1;
        private Button pic2;
        private Button pic3;
        private Button pic4;
        private Button pic6;
        private Button pic7;
        private Button pic8;
        private Button pic9;
        private bool IsWin = false;
        private readonly int firstColumn = 150;
        private readonly int secondColumn = 305;
        private readonly int thirdColumn = 460;
        private readonly int firstRow = 450;
        private readonly int seconRow = 605;
        private readonly int thirdRow = 760;
        private readonly int blockSize = 150;
        private readonly Texture2D background;

        public ArchitectureTask(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            background = content.Load<Texture2D>("room110");
            var image1 = content.Load<Texture2D>("image_part_001");
            var image2 = content.Load<Texture2D>("image_part_002");
            var image3 = content.Load<Texture2D>("image_part_003");
            var image4 = content.Load<Texture2D>("image_part_004");
            var image5 = content.Load<Texture2D>("image_part_005");
            var image6 = content.Load<Texture2D>("image_part_006");
            var image7 = content.Load<Texture2D>("image_part_007");
            var image8 = content.Load<Texture2D>("image_part_008");
            var image9 = content.Load<Texture2D>("image_part_009");

            pic7 = new Button(image7, Game.buttonFont)
            {
                Position = new Vector2(firstRow, firstColumn),
                Width = blockSize,
                Height = blockSize,
            };

            pic4 = new Button(image4, Game.buttonFont)
            {
                Position = new Vector2(seconRow, firstColumn),
                Width = blockSize,
                Height = blockSize,
            };

            pic1 = new Button(image1, Game.buttonFont)
            {
                Position = new Vector2(thirdRow, firstColumn),
                Width = blockSize,
                Height = blockSize,
            };

            pic3 = new Button(image3, Game.buttonFont)
            {
                Position = new Vector2(firstRow, secondColumn),
                Width = blockSize,
                Height = blockSize,
            };

            centre = new Button(image5, Game.buttonFont)
            {
                Position = new Vector2(seconRow, secondColumn),
                Width = blockSize,
                Height = blockSize,
            };

            pic9 = new Button(image9, Game.buttonFont)
            {
                Position = new Vector2(thirdRow, secondColumn),
                Width = blockSize,
                Height = blockSize,
            };

            pic8 = new Button(image8, Game.buttonFont)
            {
                Position = new Vector2(firstRow, thirdColumn),
                Width = blockSize,
                Height = blockSize,
            };

            pic6 = new Button(image6, Game.buttonFont)
            {
                Position = new Vector2(seconRow, thirdColumn),
                Width = blockSize,
                Height = blockSize,
            };

            pic2 = new Button(image2, Game.buttonFont)
            {
                Position = new Vector2(thirdRow, thirdColumn),
                Width = blockSize,
                Height = blockSize,
            };

            BackToHallway = new Button(Game.buttonTexture, Game.buttonFont)
            {
                Position = new Vector2(10, 10),
                Width = Game.buttonWidth,
                Height = Game.buttonHeight,
                Text = "НАЗАД",
            };

            Next = Game.Next;

            pic1.Click += Pic1_Click;
            pic2.Click += Pic2_Click;
            pic3.Click += Pic3_Click;
            pic4.Click += Pic4_Click;
            pic6.Click += Pic6_Click;
            pic7.Click += Pic7_Click;
            pic8.Click += Pic8_Click;
            pic9.Click += Pic9_Click;
            BackToHallway.Click += BackToHallway_Click;
            Next.Click += Next_Click;
            components = new List<Component>() { pic1, pic2, pic3, pic4, centre, pic6, pic7, pic8, pic9 };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), new Rectangle(0, 0, background.Width, background.Height), Color.White);
            BackToHallway.Draw(gameTime, spriteBatch);
            spriteBatch.Draw(Game.Table, new Rectangle(200, 10, 1010, 700), Color.White);
            spriteBatch.DrawString(Game.buttonFont, "Соберите картинку, передвигая центральный блок", new Vector2(400, 75), Color.Brown);

            foreach (var block in components)
                block.Draw(gameTime, spriteBatch);

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
        }

        public override void Update(GameTime gameTime)
        {
            CheckWin();
            BackToHallway.Update(gameTime);
            if (IsWin) Next.Update(gameTime);
            foreach (var block in components)
                block.Update(gameTime);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (IsWin)
            {
                Game.Score += Game.Prize;
                GameStage.IsGiven_ArchitectureGame = true;
                IsWin = false;
            }
            Game.ChangeStage(new GameStage(Game, GraphicsDevice, ContentManager));
        }

        private void Pic1_Click(object sender, EventArgs e)
        {
            ChangePosition(pic1);
        }

        private void Pic2_Click(object sender, EventArgs e)
        {
            ChangePosition(pic2);
        }

        private void Pic3_Click(object sender, EventArgs e)
        {
            ChangePosition(pic3);
        }

        private void Pic4_Click(object sender, EventArgs e)
        {
            ChangePosition(pic4);
        }

        private void Pic6_Click(object sender, EventArgs e)
        {
            ChangePosition(pic6);
        }

        private void Pic7_Click(object sender, EventArgs e)
        {
            ChangePosition(pic7);
        }

        private void Pic8_Click(object sender, EventArgs e)
        {
            ChangePosition(pic8);
        }

        private void Pic9_Click(object sender, EventArgs e)
        {
            ChangePosition(pic9);
        }

        public void ChangePosition(Button button)
        {
            var oldPosition = button.Position;
            button.Position = centre.Position;
            centre.Position = oldPosition;
        }

        private void BackToHallway_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(new GameStage(Game, GraphicsDevice, ContentManager));
        }

        private void CheckWin()
        {
            IsWin = ((pic1.Position.X == firstRow && pic1.Position.Y == firstColumn) &&
                   (pic2.Position.X == seconRow && pic2.Position.Y == firstColumn) &&
                   (pic3.Position.X == thirdRow && pic3.Position.Y == firstColumn) &&
                   (pic4.Position.X == firstRow && pic4.Position.Y == secondColumn) &&
                   (centre.Position.X == seconRow && centre.Position.Y == secondColumn) &&
                   (pic6.Position.X == thirdRow && pic6.Position.Y == secondColumn) &&
                   (pic7.Position.X == firstRow && pic7.Position.Y == thirdColumn) &&
                   (pic8.Position.X == seconRow && pic8.Position.Y == thirdColumn) &&
                   (pic9.Position.X == thirdRow && pic9.Position.Y == thirdColumn));
        }
    }
}

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics.Metrics;

namespace Vantuz
{
    public class Instruction : Stage
    {
        private readonly Button Understand;
        private readonly Texture2D enter;
        private readonly Texture2D arrow_left;
        private readonly Texture2D arrow_right;
        private readonly Texture2D arrow_up;
        private readonly Texture2D arrow_down;
        private readonly Texture2D mouse;
        private readonly Texture2D cursor;
        private readonly int iconSize = 50;
        
        public Instruction(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            enter = content.Load<Texture2D>("enter");
            arrow_left = content.Load<Texture2D>("arrow-left");
            arrow_right = content.Load<Texture2D>("arrow-right");
            arrow_up = content.Load<Texture2D>("arrow-up");
            arrow_down = content.Load<Texture2D>("arrow-down");
            mouse = content.Load<Texture2D>("mouse");
            cursor = content.Load<Texture2D>("cursor");
            Understand = new Button(Game.Table, Game.buttonFont)
            {
                Position = new Vector2(520, 570),
                Width = Game.buttonWidth,
                Height = Game.buttonHeight,
                Text = "ПОНЯЛ",
            };

            Understand.Click += StartGame_Click;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game.MenuBackground, new Rectangle(0, 0, 1280, 720), Color.DarkGray);
            spriteBatch.Draw(Game.Table, new Rectangle(100, 10, 1060, 700), Color.LightYellow);
            Understand.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(Game.buttonFont, "ДОБРО ПОЖАЛОВАТЬ В ОБЩАГУ, САЛАГА!", new Vector2(400, 65), Color.Brown);
            spriteBatch.DrawString(Game.buttonFont, "Чтобы выжить здесь, запомни несколько правил:", new Vector2(200, 100), Color.Brown);
            spriteBatch.DrawString(Game.buttonFont, "Для перемещения по коридорам общаги используй стрелки", new Vector2(400, 190), Color.Brown);
            spriteBatch.Draw(arrow_up, new Rectangle(230, 150, iconSize, iconSize), Color.White);
            spriteBatch.Draw(arrow_left, new Rectangle(170, 205, iconSize, iconSize), Color.White);
            spriteBatch.Draw(arrow_down, new Rectangle(230, 205, iconSize, iconSize), Color.White);
            spriteBatch.Draw(arrow_right, new Rectangle(290, 205, iconSize, iconSize), Color.White);
            spriteBatch.DrawString(Game.buttonFont, "Чтобы воспользоваться кнопкой, наведи на нее курсор", new Vector2(400, 305), Color.Brown);
            spriteBatch.DrawString(Game.buttonFont, "и кликни левой кнопкой мыши", new Vector2(400, 325), Color.Brown);
            spriteBatch.Draw(cursor, new Rectangle(200, 300, iconSize, iconSize), Color.White);
            spriteBatch.Draw(mouse, new Rectangle(260, 300, iconSize, iconSize), Color.White);
            spriteBatch.DrawString(Game.buttonFont, "Чтобы зайти в комнату, нажми ENTER", new Vector2(400, 405), Color.Brown);
            spriteBatch.Draw(enter, new Rectangle(220, 375, 75, 75), Color.White);
            spriteBatch.DrawString(Game.buttonFont, "Помни, что помощь не всегда бескорыстна, иногда надо что-то дать взамен!", new Vector2(200, 490), Color.Brown);
            spriteBatch.DrawString(Game.buttonFont, "Удачи!", new Vector2(580, 520), Color.Brown);
        }

        public override void Update(GameTime gameTime)
        {
            Understand.Update(gameTime);
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(new MenuStage(Game, GraphicsDevice, ContentManager));
        }
    }
}

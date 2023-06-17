using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;

namespace Vantuz
{
    public class Introduction : Stage
    {
        private readonly List<string> lines;
        private readonly Button StartGame;
        
        public Introduction(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            lines = File.ReadLines("Introduction.txt").ToList();
            StartGame = new Button(Game.Table, Game.buttonFont)
            {
                Position = new Vector2(520, 570),
                Width = Game.buttonWidth,
                Height = Game.buttonHeight,
                Text = "ПОГНАЛИ!",
            };

            StartGame.Click += StartGame_Click;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game.MenuBackground, new Rectangle(0, 0, 1280, 720), Color.DarkGray);
            spriteBatch.Draw(Game.Table, new Rectangle(100, 10, 1060, 700), Color.LightYellow);
            StartGame.Draw(gameTime, spriteBatch);
            var start = 80;
            foreach (var i in lines)
            {
                spriteBatch.DrawString(Game.buttonFont, i, new Vector2(200, start), Color.Brown);
                start += 30;
            }
        }

        public override void Update(GameTime gameTime)
        {
            StartGame.Update(gameTime);
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(new GameStage(Game, GraphicsDevice, ContentManager));
        }
    }
}


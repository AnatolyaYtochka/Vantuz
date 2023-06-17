using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace Vantuz
{
    public class MenuStage: Stage
    {
        private List<Component> components;
        private readonly Texture2D name;

        public MenuStage(Game1 game, GraphicsDevice graphicsDevice, ContentManager content): base(game, graphicsDevice, content)
        {
            Game.Song = content.Load<Song>("menu_music");
            if (Game.IsMusicOn) MediaPlayer.Play(Game.Song);
            name = content.Load<Texture2D>("name");
            Button.PlayerInHallway = false;

            var newGameButton = new Button(Game.buttonTexture, Game.buttonFont)
            {
                Position = new Vector2(540, 300),
                Width = Game.buttonWidth,
                Height = Game.buttonHeight,
                Text = "ИГРАТЬ",
            };

            var instructionsGameButton = new Button(Game.buttonTexture, Game.buttonFont)
            {
                Position = new Vector2(540, 400),
                Width = Game.buttonWidth,
                Height = Game.buttonHeight,
                Text = "ИНСТРУКЦИЯ",
            };

            var exitGameButton = new Button(Game.buttonTexture, Game.buttonFont)
            {
                Position = new Vector2(540, 500),
                Width = Game.buttonWidth,
                Height = Game.buttonHeight,
                Text = "ВЫХОД",
            };

            newGameButton.Click += NewGameButton_Click;
            instructionsGameButton.Click += InstructionsButton_Click;
            exitGameButton.Click += ExitGameButton_Click;
            components = new List<Component>() { newGameButton, instructionsGameButton, exitGameButton };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game.MenuBackground, new Rectangle(0, 0, 1280, 720), Color.White);
            spriteBatch.Draw(name, new Rectangle(300, -50, 700, 400), new Rectangle(0, 0, name.Width, name.Height), Color.White);
            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);
        }


        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(new Introduction(Game, GraphicsDevice, ContentManager));
        }

        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            Game.ChangeStage(new Instruction(Game, GraphicsDevice, ContentManager));
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
                component.Update(gameTime);
        }

        private void ExitGameButton_Click(object sender, EventArgs e)
        {
            Game.Exit();
        }
    }
}

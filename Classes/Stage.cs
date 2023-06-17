using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Vantuz
{
    public abstract class Stage
    {
        protected ContentManager ContentManager;
        protected GraphicsDevice GraphicsDevice;
        protected Game1 Game;

        public Stage(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            Game = game;
            GraphicsDevice = graphicsDevice;
            ContentManager = content;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}

﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Vantuz
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
    }
}

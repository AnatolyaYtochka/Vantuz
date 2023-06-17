using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Vantuz
{
    public class Button : Component
    {
        private MouseState currentMouse;
        private SpriteFont spriteFont;
        private bool isHovering;
        private MouseState previousMouse;
        private Texture2D textureButton;
        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }
        public string Text { get; set; }
        public int Width { get; set; }  
        public int Height { get; set; }
        public Color Colour { get; set; }
        public static bool PlayerInHallway { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            }
        }

        public Button(Texture2D texture, SpriteFont font)
        {
            textureButton = texture;
            spriteFont = font;
            PenColour = Color.Brown;
            Colour = Color.White;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Colour = Color.White;
            if (isHovering) Colour = Color.Orange;
            spriteBatch.Draw(textureButton, Rectangle, Colour);
            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (spriteFont.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (spriteFont.MeasureString(Text).Y / 2);
                spriteBatch.DrawString(spriteFont, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();
            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
            isHovering = false;
            if (mouseRectangle.Intersects(Rectangle) && (!PlayerInHallway || (currentMouse.X > 1000 && currentMouse.Y < 50)))
            {
                isHovering = true;
                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                    Click?.Invoke(this, new EventArgs());
            }

            if (Player.Rectangle.Intersects(Rectangle) && PlayerInHallway)
            {
                isHovering = true;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    Click?.Invoke(this, new EventArgs());
            }
        }
    }
}


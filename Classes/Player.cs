using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;

namespace Vantuz
{

    public class Player : Component
    {
        public static Vector2 Position { get; set; }
        public static Texture2D playerStand { get; set; }
        public static Texture2D playerGoLeft { get; set; }
        public static Texture2D playerGoRight { get; set; }
        public static Texture2D playerGoUp { get; set; }
        public static Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, 100, 150); }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) spriteBatch.Draw(playerGoRight, Rectangle, Color.White);
            else if (Keyboard.GetState().IsKeyDown(Keys.Left)) spriteBatch.Draw(playerGoLeft, Rectangle, Color.White);
            else if (Keyboard.GetState().IsKeyDown(Keys.Up)) spriteBatch.Draw(playerGoUp, Rectangle, Color.White);
            else spriteBatch.Draw(playerStand, Rectangle, Color.White);   
        }

        private readonly int leftBorder = 0;
        private int rightBorder = 1200;
        private int ladderBorderLeft = 1000;
        private int ladderBorderRight = 1100;
        private int ladderBorderDown= 500;
        private int ladderBorderUp = 150;

        public override void Update(GameTime gameTime)
        {
            var position = new Vector2();
            var speed = 3;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && Position.X > leftBorder && !CheckPlayerInLadderZone()) position.X = -speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) && Position.X < rightBorder && !CheckPlayerInLadderZone()) position.X = speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && Position.X < ladderBorderRight && Position.X > ladderBorderLeft && Position.Y > ladderBorderUp) position.Y = -speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && Position.X < ladderBorderRight && Position.X > ladderBorderLeft && Position.Y < ladderBorderDown) position.Y = speed;
            Position += position;
        }

        public bool CheckPlayerInLadderZone()
        {
            return (Position.X > ladderBorderLeft && Position.X < ladderBorderRight && Position.Y < ladderBorderDown && Position.Y > ladderBorderUp);
        }
    }
}

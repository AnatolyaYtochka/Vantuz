using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;
using System.Reflection.Metadata;
using System.IO;
using System.Linq;

namespace Vantuz
{
    public class GameStage: Stage
    {
        private readonly Texture2D background;
        private readonly Texture2D door;
        private readonly Texture2D ladder;
        private readonly Player player;
        private readonly List<Component> components;
        public static bool IsGiven_MathGame;
        public static bool IsGiven_EconomicGame;
        public static bool IsGiven_ArchitectureGame;
        public static bool IsPlayerHavePaperBill = false;
        public static bool IsGameOver = false;

        private readonly Song annaSong;
        private readonly Texture2D annaBackground;
        private readonly Texture2D annaPerson;
        private readonly List<string> annaLines;

        private readonly Song ksushaSong;
        private readonly Texture2D ksushaBackground;
        private readonly Texture2D ksushaPerson;
        private readonly List<string> ksushaLines;

        private readonly Song petyaSong;
        private readonly Texture2D petyaBackground;
        private readonly Texture2D petyaPerson;
        private readonly List<string> petyaLines;

        private readonly Song aliceSong;
        private readonly Texture2D aliceBackground;
        private readonly Texture2D alicePerson;
        private readonly List<string> aliceLines;

        private readonly Song lehaSong;
        private readonly Texture2D lehaBackground;
        private readonly Texture2D lehaPerson;
        private readonly List<string> lehaLines;

        private readonly Song mishaSong;
        private readonly Texture2D mishaBackground;
        private readonly Texture2D mishaPerson;
        private readonly List<string> mishaLines;
        private readonly List<string> mishaLines_WithoutMoney;

        private readonly Song katyaSong;
        private readonly Texture2D katyaBackground;
        private readonly Texture2D katyaPerson;
        private readonly List<string> katyaLines;
        private readonly List<string> katyaLines_ChangeMoney;

        private readonly Song rickrollSong;
        private readonly Texture2D rickrollBackground;
        private readonly string rickrollText;

        private readonly Song boomSong;
        private readonly Texture2D boomBackground;
        private readonly string boomText;

        private readonly Song closeDoorSong;
        private readonly Texture2D closeDoorBackground;
        private readonly string closeDoorText;

        public GameStage(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            Game.Song = content.Load<Song>("hallway_music");
            if (Game.IsMusicOn) MediaPlayer.Play(Game.Song);
            background = content.Load<Texture2D>("dormotory");
            Button.PlayerInHallway = true;
            Player.Position = Game.CurrentPosition;
            Player.playerStand = ContentManager.Load<Texture2D>("playerStand");
            Player.playerGoRight = ContentManager.Load<Texture2D>("playerGoRight");
            Player.playerGoLeft = ContentManager.Load<Texture2D>("playerGoLeft");
            Player.playerGoUp = ContentManager.Load<Texture2D>("playerGoUp");

            annaSong = content.Load<Song>("MathGame");
            annaBackground = content.Load<Texture2D>("room107");
            annaPerson = content.Load<Texture2D>("Anna");
            annaLines = File.ReadLines("Anna.txt").ToList();

            ksushaSong = content.Load<Song>("ERMusic");
            ksushaBackground = content.Load<Texture2D>("room1");
            ksushaPerson = content.Load<Texture2D>("Ksusha");
            ksushaLines = File.ReadLines("Ksusha.txt").ToList();

            aliceSong = content.Load<Song>("AliceSong");
            aliceBackground = content.Load<Texture2D>("room104");
            alicePerson = content.Load<Texture2D>("Alice");
            aliceLines = File.ReadLines("Alice.txt").ToList();

            petyaSong = content.Load<Song>("ARMusic");
            petyaBackground = content.Load<Texture2D>("room110");
            petyaPerson = content.Load<Texture2D>("Petya");
            petyaLines = File.ReadLines("Petya.txt").ToList();

            lehaSong = content.Load<Song>("LehaSong");
            lehaBackground = content.Load<Texture2D>("chill_room");
            lehaPerson = content.Load<Texture2D>("Leha");
            lehaLines = File.ReadLines("Leha.txt").ToList();

            mishaSong = content.Load<Song>("MishaSong");
            mishaBackground = content.Load<Texture2D>("room203");
            mishaPerson = content.Load<Texture2D>("Misha");
            mishaLines_WithoutMoney = File.ReadLines("Misha_withoutMoney.txt").ToList();
            mishaLines = File.ReadLines("Misha_withMoney.txt").ToList();

            katyaSong = content.Load<Song>("KatyaSong");
            katyaBackground = content.Load<Texture2D>("KatyaRoom");
            katyaPerson = content.Load<Texture2D>("Katya");
            katyaLines = File.ReadLines("Katya.txt").ToList();
            katyaLines_ChangeMoney = File.ReadLines("Katya_ChangeMoney.txt").ToList();

            rickrollSong = content.Load<Song>("rickroll");
            rickrollBackground = content.Load<Texture2D>("rick");
            rickrollText = "Вас зарикроллили:(";

            boomSong = content.Load<Song>("boom");
            boomBackground = content.Load<Texture2D>("boom_man");
            boomText = "Вы очень не вовремя...";

            closeDoorSong = content.Load<Song>("theme");
            closeDoorBackground = content.Load<Texture2D>("mem");
            closeDoorText = "Похоже, здесь никого нет...";

            door = ContentManager.Load<Texture2D>("door");
            ladder = ContentManager.Load<Texture2D>("ladder");
            player = new Player();
            var doorFont = ContentManager.Load<SpriteFont>("Font");
            var doorWidth = 150;
            var doorHeight = 200;
            var firstFloor = 422;
            var secondFloor = 62;

            var ksushaRoom = new Button(door, doorFont)
            {
                Position = new Vector2(200, firstFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "102",
                PenColour = Color.White,
            };

            var rickrollRoom = new Button(door, doorFont)
            {
                Position = new Vector2(400, firstFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "103",
                PenColour = Color.White,
            };

            var katyaRoom = new Button(door, doorFont)
            {
                Position = new Vector2(600, firstFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "104",
                PenColour = Color.White,
            };

            var lehaRoom = new Button(door, doorFont)
            {
                Position = new Vector2(800, firstFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "105",
                PenColour = Color.White,
            };

            var petyaRoom = new Button(door, doorFont)
            {
                Position = new Vector2(0, secondFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "201",
                PenColour = Color.White,
            };

            var boomRoom = new Button(door, doorFont)
            {
                Position = new Vector2(200, secondFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "202",
                PenColour = Color.White,
            };

            var aliceRoom = new Button(door, doorFont)
            {
                Position = new Vector2(400, secondFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "203",
                PenColour = Color.White,
            };

            var closeRoom = new Button(door, doorFont)
            {
                Position = new Vector2(600, secondFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "204",
                PenColour = Color.White,
            };

            var mishaRoom = new Button(door, doorFont)
            {
                Position = new Vector2(800, secondFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "205",
                PenColour = Color.White,
            };

            var annaRoom = new Button(door, doorFont)
            {
                Position = new Vector2(1000, secondFloor),
                Width = doorWidth,
                Height = doorHeight,
                Text = "206",
                PenColour = Color.White,
            };

            ksushaRoom.Click += KsushaGameRoom_Click;
            katyaRoom.Click += KatyaRoom_Click;
            mishaRoom.Click += MishaRoom_Click;
            annaRoom.Click += AnnaGameRoom_Click;
            petyaRoom.Click += PetyaGameRoom_Click;
            rickrollRoom.Click += Rickroll_Click;
            closeRoom.Click += CloseRoom_Click;
            boomRoom.Click += BoomRoom_Click;
            aliceRoom.Click += AliceRoom_Click;
            lehaRoom.Click += LehaRoom_Click;
            components = new List<Component>() { ksushaRoom, rickrollRoom, closeRoom, annaRoom, katyaRoom, boomRoom, aliceRoom, petyaRoom, mishaRoom, lehaRoom };
        }


        private void CloseRoom_Click(object sender, EventArgs e)
        {
            Button.PlayerInHallway = false;
            Game.Song = closeDoorSong;
            CloseDoor.Background = closeDoorBackground;
            CloseDoor.Text = closeDoorText;
            Game.ChangeStage(new CloseDoor(Game, GraphicsDevice, ContentManager));
        }

        private void BoomRoom_Click(object sender, EventArgs e)
        {
            Button.PlayerInHallway = false;
            Game.Song = boomSong;
            CloseDoor.Background = boomBackground;
            CloseDoor.Text = boomText;
            Game.ChangeStage(new CloseDoor(Game, GraphicsDevice, ContentManager));
        }

        private void Rickroll_Click(object sender, EventArgs e)
        {
            Button.PlayerInHallway = false;
            Game.Song = rickrollSong;
            CloseDoor.Background = rickrollBackground;
            CloseDoor.Text = rickrollText;
            Game.ChangeStage(new CloseDoor(Game, GraphicsDevice, ContentManager));
        }

        private void AliceRoom_Click(object sender, EventArgs e)
        {
            Button.PlayerInHallway = false;
            DialogRoom.IsNeedToStartGame = false;
            Game.Song = aliceSong;
            DialogRoom.Background = aliceBackground;
            DialogRoom.Person = alicePerson;
            DialogRoom.Lines = aliceLines;
            Game.ChangeStage(new DialogRoom(Game, GraphicsDevice, ContentManager));
        }

        private void KsushaGameRoom_Click(object sender, EventArgs e)
        {
            if (!IsGiven_EconomicGame)
            {
                Button.PlayerInHallway = false;
                DialogRoom.IsNeedToStartGame = true;
                Game.Song = ksushaSong;
                DialogRoom.Background = ksushaBackground;
                DialogRoom.Person = ksushaPerson;
                DialogRoom.Lines = ksushaLines;
                DialogRoom.MiniGameStage = new EconomicTask(Game, GraphicsDevice, ContentManager);
                Game.ChangeStage(new DialogRoom(Game, GraphicsDevice, ContentManager));
            }
        }

        private void MishaRoom_Click(object sender, EventArgs e)
        {
            Button.PlayerInHallway = false;
            DialogRoom.IsNeedToStartGame = false;
            Game.Song = mishaSong;
            DialogRoom.Background = mishaBackground;
            DialogRoom.Person = mishaPerson;
            if (IsPlayerHavePaperBill)
            {
                IsGameOver = true;
                DialogRoom.Lines = mishaLines;
            }
            else DialogRoom.Lines = mishaLines_WithoutMoney;
            Game.ChangeStage(new DialogRoom(Game, GraphicsDevice, ContentManager));
        }

        private void KatyaRoom_Click(object sender, EventArgs e)
        {
            Button.PlayerInHallway = false;
            DialogRoom.IsNeedToStartGame = false;
            Game.Song = katyaSong;
            DialogRoom.Background = katyaBackground;
            DialogRoom.Person = katyaPerson;
            if (Game.Score == 99)
            {
                DialogRoom.Lines = katyaLines_ChangeMoney;
                IsPlayerHavePaperBill = true;
                Game.Score = 100;
            }
            else DialogRoom.Lines = katyaLines;
            Game.ChangeStage(new DialogRoom(Game, GraphicsDevice, ContentManager));
        }

        private void AnnaGameRoom_Click(object sender, EventArgs e)
        {
            if (!IsGiven_MathGame)
            {
                Button.PlayerInHallway = false;
                DialogRoom.IsNeedToStartGame = true;
                Game.Song = annaSong;
                DialogRoom.Background = annaBackground;
                DialogRoom.Person = annaPerson;
                DialogRoom.Lines = annaLines;
                DialogRoom.MiniGameStage = new MathTask(Game, GraphicsDevice, ContentManager);
                Game.ChangeStage(new DialogRoom(Game, GraphicsDevice, ContentManager));
            }
        }

        private void LehaRoom_Click(object sender, EventArgs e)
        {
            Button.PlayerInHallway = false;
            DialogRoom.IsNeedToStartGame = false;
            Game.Song = lehaSong;
            DialogRoom.Background = lehaBackground;
            DialogRoom.Person = lehaPerson;
            DialogRoom.Lines = lehaLines;
            Game.ChangeStage(new DialogRoom(Game, GraphicsDevice, ContentManager));
        }

        private void PetyaGameRoom_Click(object sender, EventArgs e)
        {
            if (!IsGiven_ArchitectureGame)
            {
                Button.PlayerInHallway = false;
                DialogRoom.IsNeedToStartGame = true;
                Game.Song = petyaSong;
                DialogRoom.Background = petyaBackground;
                DialogRoom.Person = petyaPerson;
                DialogRoom.Lines = petyaLines;
                DialogRoom.MiniGameStage = new ArchitectureTask(Game, GraphicsDevice, ContentManager);
                Game.ChangeStage(new DialogRoom(Game, GraphicsDevice, ContentManager));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(-10, 0, 1500, 720), Color.White);
            spriteBatch.Draw(door, new Rectangle(0, 422, 150, 200), Color.White);
            spriteBatch.Draw(ladder, new Rectangle(1000, 250, 200, 375), Color.White);
            spriteBatch.DrawString(Game.buttonFont, $"SCORE: {Game.Score}", new Vector2(50, 30), Color.Brown);
            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);
            player.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
                component.Update(gameTime);
            player.Update(gameTime);
            Game.CurrentPosition = Player.Position;
        }
    }
}

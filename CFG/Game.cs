using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using GameLibrary.CFG.UI;
using GameLibrary.CFG.Config;
using GameLibrary.CFG.Objects;
using GameLibrary.CFG.Objects.DataTypes;

namespace GameLibrary.CFG
{
    // Abstract class for the Game itself
    public abstract class Game : Form
    {
        private Renderer render; // Renderer to render game objects

        public Game() : base()
        {
            this.DoubleBuffered = true;
            InitaliseGameComponents();
            InitaliseFormComponents();
        }

        // Initialise essential game components
        private void InitaliseGameComponents()
        {
            Settings.SetResolution(Settings.FULLHD);
            render = new Renderer(new Vector(Settings.Resolution.x, Settings.Resolution.y), new Vector(this.Width, this.Height));
            InitaliseGame();
        }
        
        // Add the key listener
        private void InitaliseFormComponents()
        {
            this.KeyDown += OnKeyDown;
            this.ResizeEnd += GameResizeEnd;
            this.SizeChanged += GameSizeChanged;
        }

        // Create the game loop
        public void GameLoop()
        {
            while (this.Created)
            {
                GameLogic();
                RenderScene();
                Application.DoEvents();
                Thread.Sleep(50);
            }
        }
            
        // Tell the renderer to draw the game screen
        private void RenderScene()
        {
            render.render();
            this.Invalidate();
        }

        // Draw the game screen to the form
        protected override void OnPaint(PaintEventArgs e)
        {
            render.paint(e.Graphics);
        }

        // Add Sprites to the game
        public void AddSprite(Sprite s)
        {
            render.set(s);
        }

        // Handle the resizing the screen
        private void GameResizeEnd(Object sender, EventArgs e)
        {
            render.UpdateScreenSize(new Vector(this.Width, this.Height));
        }

        // Handle other forms of resizing such as maximised or minimised form
        private void GameSizeChanged(Object sender, EventArgs e)
        {
            render.UpdateScreenSize(new Vector(this.Width, this.Height));
        }

        public abstract void InitaliseGame(); // Override method to allow developer to initalise their own objects
        
        public abstract void OnKeyDown(object sender, KeyEventArgs e); // Override method to allow developer to handle key presses

        public abstract void GameLogic(); // Override method to allow developer to write the logic behind the game

    }
}

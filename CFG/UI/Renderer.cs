using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

using GameLibrary.CFG.Objects;
using GameLibrary.CFG.Objects.DataTypes;

namespace GameLibrary.CFG.UI
{
    public class Renderer
    {
        private Bitmap canvas; // The Canvas for which game objects are drawn on.
        private Graphics fg; // The graphics object for drawing onto the Canvas

        private Color BACKGROUND_COLOR = Color.Black; // Background colour

        private List<Sprite> sprites = new List<Sprite>(); // List of sprites to draw

        private Vector Resolution, ScreenSize; // Vectors containing the size of resolution and the size of screen

        private double ratio; // the aspect ratio

        // Initialise the renderer
        public Renderer(Vector res, Vector screen)
        {
            // Figure out the ratio
            this.Resolution = res;
            this.ScreenSize = screen;

            double ratioX = (double)Resolution.x / (double)ScreenSize.y;
            double ratioY = (double)Resolution.y / (double)ScreenSize.y;
            // use whichever multiplier is smaller
            ratio = ratioX < ratioY ? ratioX : ratioY;

            // Create the Game Canvas for drawing sprites onto.
            canvas = new Bitmap(Convert.ToInt32(ScreenSize.x * ratio), Convert.ToInt32(ScreenSize.y * ratio));

            // Set up the graphic configs for the renderer
            fg = Graphics.FromImage(canvas);
            fg.InterpolationMode = InterpolationMode.HighQualityBicubic;
            fg.SmoothingMode = SmoothingMode.HighQuality;
            fg.PixelOffsetMode = PixelOffsetMode.HighQuality;
            fg.CompositingQuality = CompositingQuality.HighQuality;
        }

        // Add sprites to the sprite list for drawing
        public void set(Sprite spr)
        {
            sprites.Add(spr);
        }

        // Draw the sprites to the canvas
        public void render()
        {
            fg.Clear(BACKGROUND_COLOR);
            foreach (Sprite spr in sprites)
            {
                if (spr.IsShape())
                {
                    fg.FillRectangle(Brushes.Wheat, AspectRatio(spr.position.x), AspectRatio(spr.position.y), AspectRatio(spr.size.x), AspectRatio(spr.size.y));
                }
            }
        }

        // work out the new size dependent on the aspect ratio
        private int AspectRatio(int s)
        {
            return Convert.ToInt32(s*ratio);
        }

        // Update the screen size
        public void UpdateScreenSize(Vector s)
        {
            this.ScreenSize = s;
        }

        // Draw the canvas to the form
        public void paint(Graphics g)
        {
            render();
            g.DrawImage(canvas, 0, 0, ScreenSize.x, ScreenSize.y);
        }
    }
}

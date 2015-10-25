using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using GameLibrary.CFG.Objects.DataTypes;

namespace GameLibrary.CFG.Objects
{
    // Sprite class to hold game sprites
    public class Sprite
    {
        public Bitmap img; // Image for the sprite
        public Vector position; // Vector to hold the position of the sprite
        public Vector size; // Vector to hold the size of the sprite

        private bool shape = false; // Boolean to define if the sprite is just a rectangle

        // Constructor that defines the sprite as an image
        public Sprite(Bitmap img, int x, int y)
        {
            this.img = img;
            this.position = new Vector(x, y);
            this.size = new Vector(img.Width, img.Height);
        }

        // Constructor that defines the sprite as a rectangle
        public Sprite(int x, int y, int w, int h)
        {
            this.position = new Vector(x, y);
            this.size = new Vector(w, h);
            this.shape = true;
        }

        // Boolean that returns whether the sprite is a rectangle or image
        public bool IsShape()
        {
            return this.shape;
        }
    }
}

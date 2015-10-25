namespace GameLibrary.CFG.Objects.DataTypes
{
    // Create vectors from co-ordinates
    public class Vector
    {
        
        public int x, y, z; // x, y and z co-ordinates

        // Create a 2D vector
        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Create a 3D vector
        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

    }
}

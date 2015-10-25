using GameLibrary.CFG.Objects.DataTypes;

namespace GameLibrary.CFG.Config
{
    public class Settings
    {
        // Declare constants for common resolutions
        public static readonly Vector FULLHD = new Vector(1920, 1080);
        public static readonly Vector HD720 = new Vector(1280, 720);
        public static readonly Vector SD720 = new Vector(720, 480);
        public static readonly Vector SD640 = new Vector(640, 480);

        // Vector to hold the current resolution
        public static Vector Resolution;


        // Set the Resolution
        public static void SetResolution(Vector r)
        {
            Resolution = r;
        }

    }
}

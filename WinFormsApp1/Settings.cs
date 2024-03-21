namespace WinFormsApp1
{
    class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static string DirectionalMove;

        public Settings()
        {
            Width = 16;
            Height = 16;
            DirectionalMove = "left";
        }
    }
}

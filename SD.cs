namespace SignalRUdemy
{
    public static class SD
    {
        public const string Wand = "wand";
        public const string Stone = "stone";
        public const string Cloak = "cloak";
        static SD()
        {
            DealthyHalloRace = new Dictionary<string, int>
            {
                {Wand, 0 },
                { Stone, 0 },
                { Cloak, 0 },
            };

        }
        public static Dictionary<string, int> DealthyHalloRace { get; set; }
    }
}

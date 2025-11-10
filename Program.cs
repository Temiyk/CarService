namespace coursa4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static class CurrentUser
        {
            public static int Id { get; set; }
            public static string Name { get; set; } = string.Empty;
            public static bool IsAuthenticated => Id > 0;

            public static void Clear()
            {
                Id = 0;
                Name = string.Empty;
            }

            public static void SetUser(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Authorization());
        }
    }
}
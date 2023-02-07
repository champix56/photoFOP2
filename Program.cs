namespace photoFOP2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\TEMP"))
            {
                System.IO.Directory.Delete(System.IO.Directory.GetCurrentDirectory() + "\\TEMP",true);
            }
            System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\TEMP");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PhotoFOP());
              
                System.IO.Directory.Delete(System.IO.Directory.GetCurrentDirectory() + "\\TEMP",true);
           
        }
    }
}
using System;
using System.Reflection;
using System.Windows.Forms;

namespace FTDI_USB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            LoadLib("FTD2XX.DLL");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormFTDI_Debug());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string resourceName = new AssemblyName(args.Name).Name + ".dll";
            string resource = Array.Find(Assembly.GetExecutingAssembly().GetManifestResourceNames(), element => element.EndsWith(resourceName));

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                stream.Flush();
                stream.Close();
                return Assembly.Load(assemblyData);
            }
        }
        private static bool LoadLib(string libraryName)
        {
            string resourceName =  Array.Find(Assembly.GetExecutingAssembly().GetManifestResourceNames(), element => element.EndsWith(libraryName));
            var path = DebugToolsLib.LoadLibs.LoadUnmanagedLibraryFromResource(
                Assembly.GetExecutingAssembly(), resourceName, libraryName);

            DebugToolsLib.MessageCLI.Debug("Loaded library:" + path);
            return true;
        }
    }
}

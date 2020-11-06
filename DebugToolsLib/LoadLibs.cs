using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DebugToolsLib
{
    public class LoadLibs
    {
        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string dllToLoad);
        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        public static string LoadUnmanagedLibraryFromResource(Assembly assembly,
            string libraryResourceName,
            string libraryName)
        {
            string tempDllPath = string.Empty;
            using (Stream s = assembly.GetManifestResourceStream(libraryResourceName))
            {
                byte[] data = new BinaryReader(s).ReadBytes((int)s.Length);

                string assemblyPath = Path.GetDirectoryName(assembly.Location);
                tempDllPath = Path.Combine(assemblyPath, libraryName);
                File.WriteAllBytes(tempDllPath, data);

            }

            LoadLibrary(libraryName);
            return tempDllPath;
        }

        public static int GetLastErrorWin32()
        {
            return Marshal.GetLastWin32Error(); // Error Code while loading DLL
        }

        /// <summary>
        /// It checks, is driver installed
        /// </summary>
        /// <param name="driverName"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static bool IsDriverInstalled(string driverName, out int errorCode)
        {
            errorCode = 0;

            //trying to load library
            string path = driverName;//@Path.GetDirectoryName(GetType().Assembly.Location) + Path.DirectorySeparatorChar + "FTD2XX.DLL";
            IntPtr handler = LoadLibs.LoadLibrary(path);
            if (handler == IntPtr.Zero)
            {
                errorCode = LoadLibs.GetLastErrorWin32();
                return false;
            }
            //Don't forget to free .dll
            LoadLibs.FreeLibrary(handler);

            return true;
        }
    }
}

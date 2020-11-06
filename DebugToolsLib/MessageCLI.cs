using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DebugToolsLib
{
    public class MessageCLI
    {
        public static string MsgPrefix = ">>> ";
        public static void Debug(string text, bool isOutputFile = true, bool isLog = true)
        {
            string debug_text =text;
            if (isLog)
                debug_text = debug_text.Insert(0, DateTime.Now.ToString("hh:mm:ss.ffff t") + " - ");
            debug_text = MsgPrefix + debug_text;
            if (isOutputFile)
                Console.WriteLine(debug_text);
            else
                System.Diagnostics.Debug.WriteLine(debug_text);
        }

        public static void Warning(string text, bool isOutputFile = true, bool isLog = true)
        {
            string debug_text = MsgPrefix + text;
            if (isLog)
                debug_text = debug_text.Insert(0, DateTime.Now.ToString("hh:mm:ss.ffff t") + " - ");
            debug_text = MsgPrefix + debug_text;
            if (isOutputFile)
                Console.WriteLine(debug_text);
            else
                System.Diagnostics.Debug.WriteLine(debug_text);
        }

        public static void Error(string text, bool isOutputFile = true, bool isLog = true)
        {
            string debug_text = MsgPrefix + "<Error>" + text;
            if (isLog)
                debug_text = debug_text.Insert(0, DateTime.Now.ToString("hh:mm:ss.ffff t") + " - ");
            debug_text = MsgPrefix + debug_text;
            if (isOutputFile)
                Console.WriteLine(debug_text);
            else
                System.Diagnostics.Debug.WriteLine(debug_text);
        }
        public static void PrintInDialog(string text, string caption = "", MessageBoxButtons mbButtons = MessageBoxButtons.OK, 
            MessageBoxIcon mbIcon = MessageBoxIcon.Error, bool isOutputFile = true, bool isLog = true)
        {
            string debug_text = "MsgBox: [" + caption + "] - " + text;
            if (isLog)
                debug_text = debug_text.Insert(0, DateTime.Now.ToString("hh:mm:ss.ffff t") + " - ");
            debug_text = MsgPrefix + debug_text;
            if (isOutputFile)
                Console.WriteLine(debug_text);
            else
                System.Diagnostics.Debug.WriteLine(debug_text);
            MessageBox.Show(text, caption, mbButtons, mbIcon);
        }
    }
}

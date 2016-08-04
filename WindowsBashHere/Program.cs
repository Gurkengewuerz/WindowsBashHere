using System;
using System.IO;
using System.Security.Principal;
using Microsoft.Win32;

namespace WindowsBashHere
{
	class MainClass
	{
		static string base64ico = "AAABAAIAEBAAAAAAIABoBAAAJgAAACAgAAAAACAAqBAAAI4EAAAoAAAAEAAAACAAAAABACAAAAAAAEAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAjwAAAPsAAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD7AAAAjwAAAPsAAACvAAAAcQAAAHEAAABxAAAAcQAAAHEAAABxAAAAcQAAAHEAAABxAAAAcQAAAHEAAABxAAAArwAAAPsAAAD/AAAAcf///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAHEAAAD/AAAA/wAAAHH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEAAABxAAAA/wAAAP8AAABx////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BAAAAcQAAAP8AAAD/AAAAcf///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAHEAAAD/AAAA/wAAAHH///8BAAAAcwAAAEv///8B////Af///wEAAABdAAAAcQAAAHEAAABxAAAAS////wEAAABxAAAA/wAAAP8AAABx////AQAAAC8AAACfAAAAywAAAF8AAAAF////Af///wH///8B////Af///wH///8BAAAAcQAAAP8AAAD/AAAAcf///wH///8B////AQAAABsAAADJAAAAnf///wH///8B////Af///wH///8B////AQAAAHEAAAD/AAAA/wAAAHH///8BAAAAGQAAAH8AAADTAAAAgQAAABX///8B////Af///wH///8B////Af///wEAAABxAAAA/wAAAP8AAABx////AQAAAIkAAABrAAAAC////wH///8B////Af///wH///8B////Af///wH///8BAAAAcQAAAP8AAAD/AAAAcf///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAHEAAAD/AAAA/wAAAOkAAADXAAAA1wAAANcAAADXAAAA1wAAANcAAADXAAAA1wAAANcAAADXAAAA1wAAANcAAADpAAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAAywAAANEAAADBAAAA2wAAAP8AAAD7AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAMMAAADLAAAAuQAAANUAAAD7AAAAjwAAAPsAAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD7AAAAjwAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8AAP//AAD//wAA//8oAAAAIAAAAEAAAAABACAAAAAAAIAQAAAAAAAAAAAAAAAAAAAAAAAAAAAAFwAAAJMAAADzAAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAADzAAAAkwAAABcAAACRAAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAAkQAAAPEAAAD/AAAA/QAAAOEAAADhAAAA4QAAAOEAAADhAAAA4QAAAOEAAADhAAAA4QAAAOEAAADhAAAA4QAAAOEAAADhAAAA4QAAAOEAAADhAAAA4QAAAOEAAADhAAAA4QAAAOEAAADhAAAA4QAAAOEAAADhAAAA/QAAAP8AAADxAAAA/wAAAP8AAADh////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEAAADhAAAA/wAAAP8AAAD/AAAA/wAAAOH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAOEAAAD/AAAA/wAAAP8AAAD/AAAA4f///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BAAAA4QAAAP8AAAD/AAAA/wAAAP8AAADh////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEAAADhAAAA/wAAAP8AAAD/AAAA/wAAAOH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAOEAAAD/AAAA/wAAAP8AAAD/AAAA4f///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BAAAA4QAAAP8AAAD/AAAA/wAAAP8AAADh////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEAAADhAAAA/wAAAP8AAAD/AAAA/wAAAOH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAOEAAAD/AAAA/wAAAP8AAAD/AAAA4f///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BAAAA4QAAAP8AAAD/AAAA/wAAAP8AAADh////Af///wH///8BAAAAMwAAAEX///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEAAADhAAAA/wAAAP8AAAD/AAAA/wAAAOH///8B////Af///wEAAABZAAAA/wAAAM8AAABZAAAAA////wH///8B////Af///wH///8BAAAAkwAAAOEAAADhAAAA4QAAAOEAAADhAAAA4QAAAOEAAADhAAAATf///wH///8B////AQAAAOEAAAD/AAAA/wAAAP8AAAD/AAAA4f///wH///8B////AQAAAB0AAACbAAAA9wAAAP8AAADfAAAAbQAAAAv///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BAAAA4QAAAP8AAAD/AAAA/wAAAP8AAADh////Af///wH///8B////Af///wEAAAATAAAAdQAAAN8AAAD/AAAA7QAAAIEAAAAV////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEAAADhAAAA/wAAAP8AAAD/AAAA/wAAAOH///8B////Af///wH///8B////Af///wH///8BAAAAAwAAAE8AAAC9AAAA/wAAAPcAAAA3////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAOEAAAD/AAAA/wAAAP8AAAD/AAAA4f///wH///8B////Af///wH///8B////Af///wH///8BAAAAFwAAAH0AAADvAAAA/wAAAEf///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BAAAA4QAAAP8AAAD/AAAA/wAAAP8AAADh////Af///wH///8B////Af///wH///8BAAAANQAAAKMAAAD5AAAA/wAAAMkAAABTAAAAA////wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEAAADhAAAA/wAAAP8AAAD/AAAA/wAAAOH///8B////Af///wEAAAAHAAAAWwAAAMkAAAD/AAAA/wAAALEAAAA9////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAOEAAAD/AAAA/wAAAP8AAAD/AAAA4f///wH///8B////AQAAAFkAAAD/AAAA+QAAAJsAAAAp////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BAAAA4QAAAP8AAAD/AAAA/wAAAP8AAADh////Af///wH///8BAAAASQAAAIUAAAAZ////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wEAAADhAAAA/wAAAP8AAAD/AAAA/wAAAOH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////AQAAAOEAAAD/AAAA/wAAAP8AAAD/AAAA4f///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8B////Af///wH///8BAAAA4QAAAP8AAAD/AAAA/wAAAP8AAAD3AAAAsQAAALEAAACxAAAAsQAAALEAAACxAAAAsQAAALEAAACxAAAAsQAAALEAAACxAAAAsQAAALEAAACxAAAAsQAAALEAAACxAAAAsQAAALEAAACxAAAAsQAAALEAAACxAAAAsQAAALEAAAD3AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP0AAAAxAAAASwAAAP8AAADrAAAAGwAAAG0AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA+QAAAB8AAAA1AAAA/wAAAOMAAAANAAAAWQAAAP8AAAD/AAAA/wAAAPEAAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA+QAAAP0AAAD/AAAA/wAAAPcAAAD/AAAA/wAAAP8AAADxAAAAkQAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAJEAAAAXAAAAkwAAAPMAAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAPMAAACTAAAAFwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
		public static void Main(string[] args)
		{
			if (!IsAdministrator())
			{
				Console.WriteLine("Please this program as admin!");
				Console.ReadLine();
				Environment.Exit(1);
			}

			while (true)
			{
				Console.Clear();
				Console.WriteLine("1) Install Contex Menu \"Windows Bash here\"");
				Console.WriteLine("2) Deinstall Contex Menu");
				Console.WriteLine("3) Exit");
				switch (Console.ReadLine())
				{
					case "1":
						install();
						break;

					case "2":
						deinstall();
						break;

					case "3":
						Environment.Exit(0);
						break;

					default:
						break;
				}
			}
		}

		static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		static string workdir = Path.Combine(appdata, "WinBashHere");
		static string dirEmpty = "Directory\\Background\\shell\\win_bash_here";
		static string folder = "Folder\\shell\\win_bash_here";
		static string folderCMD = "Folder\\shell\\win_bash_here\\command";
		static string dirEmptyCMD = "Directory\\Background\\shell\\win_bash_here\\command";
		static string name = "Windows Bash here";
		static string cmd = "bash";

		static void install()
		{
			if (!Directory.Exists(workdir))
			{
				Directory.CreateDirectory(workdir);
			}
			string icon = Path.Combine(workdir, "console32.ico");
			File.WriteAllBytes(icon, Convert.FromBase64String(base64ico));

			RegistryKey regmenu = null;
			RegistryKey regicon = null;
			RegistryKey regcmd = null;
			try
			{
				regmenu = Registry.ClassesRoot.CreateSubKey(folder);
				if (regmenu != null)
					regmenu.SetValue("", name);
				regicon = Registry.ClassesRoot.CreateSubKey(folder);
				if (regicon != null)
					regicon.SetValue("Icon", icon);
				regcmd = Registry.ClassesRoot.CreateSubKey(folderCMD);
				if (regcmd != null)
					regcmd.SetValue("", cmd);
				if (regmenu != null)
					regmenu.Close();
				if (regcmd != null)
					regcmd.Close();

				regmenu = Registry.ClassesRoot.CreateSubKey(dirEmpty);
				if (regmenu != null)
					regmenu.SetValue("", name);
				regicon = Registry.ClassesRoot.CreateSubKey(dirEmpty);
				if (regicon != null)
					regicon.SetValue("Icon", icon);
				regcmd = Registry.ClassesRoot.CreateSubKey(dirEmptyCMD);
				if (regcmd != null)
					regcmd.SetValue("", cmd);
				if (regmenu != null)
					regmenu.Close();
				if (regcmd != null)
					regcmd.Close();

				Console.WriteLine("INSTALL: Success!");
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				Console.ReadLine();
			}
		}

		static void deinstall()
		{
			try
			{
				if (Directory.Exists(workdir))
				{
					Directory.Delete(workdir, true);
				}

				RegistryKey reg = Registry.ClassesRoot.OpenSubKey(folderCMD);
				if (reg != null)
				{
					reg.Close();
					Registry.ClassesRoot.DeleteSubKey(folderCMD);
				}
				reg = Registry.ClassesRoot.OpenSubKey(folder);
				if (reg != null)
				{
					reg.Close();
					Registry.ClassesRoot.DeleteSubKey(folder);
				}

				reg = Registry.ClassesRoot.OpenSubKey(dirEmptyCMD);
				if (reg != null)
				{
					reg.Close();
					Registry.ClassesRoot.DeleteSubKey(dirEmptyCMD);
				}
				reg = Registry.ClassesRoot.OpenSubKey(dirEmpty);
				if (reg != null)
				{
					reg.Close();
					Registry.ClassesRoot.DeleteSubKey(dirEmpty);
				}

				Console.WriteLine("REMOVE: Success!");
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				Console.ReadLine();
			}
		}

		public static bool IsAdministrator()
		{
			var identity = WindowsIdentity.GetCurrent();
			var principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}

	}
}

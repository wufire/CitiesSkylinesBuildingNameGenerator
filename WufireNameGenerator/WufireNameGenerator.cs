using ICities;
using System;
using ColossalFramework.IO;
namespace WufireNameGenerator
{
	public class WufireNameGenerator : IUserMod
	{
		public static string BusinessNameFile {
			get {
				return DataLocation.modsPath + "/WufireNameGenerator/BusinessNames.json";
			}
		}

		public string Description
		{
			get
			{
				return "Creates new names for industrial, office and commercial buildings. Add your own names in the file: " + BusinessNameFile;
			}
		}
		
		public string Name
		{
			get
			{
				return "Wufire's Business Name Generator";
			}
		}
	}
}


using System;
using System.Collections.Generic;
using System.IO;

namespace SpriteGenerator
{
	// Horrible name for a class, really the worst.
	// Responsible for enumerating all the files in a directory
	public class Inputs
	{
		Dictionary<string, FileInfo[]> _files = new Dictionary<string, FileInfo[]>();

		public FileInfo[] GetParts(string partname)
		{
			return _files[partname.ToLower()];
		}

		// source is directory to look for subdirs, ext is extension of
		// files to care about.
		public Inputs(DirectoryInfo source, string ext)
		{
			ext = ext.ToLower();

			foreach (var dir in source.EnumerateDirectories())
			{
				var files = dir.GetFiles();
				var filesWeCareAbout = new List<FileInfo>();
				for (var i = 0; i < files.Length; i++)
				{
					var file = files[i];
					if (file.Extension.ToLower() == ext)
					{
						filesWeCareAbout.Add(file);
					}
				}
				_files.Add(dir.Name.ToLower(), filesWeCareAbout.ToArray());
			}
		}
	}
}

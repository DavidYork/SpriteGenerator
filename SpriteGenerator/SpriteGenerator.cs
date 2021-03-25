using System.IO;
using System.Drawing;

namespace SpriteGenerator
{
	// Generate a bunch of sprites from part files and a palette file
	public class SpriteGenerator
	{
		public static Bitmap Generate(
			DirectoryInfo source,
			string[] parts,
			FileInfo paletteFile,				// Can be null
			string imageExtension = ".png"		// Case insensitive, used for input
		)
		{
			var rand = new System.Random();

			// Enumerate all source files
			var src = new Inputs(source, imageExtension);

			// Read palette info
			PaletteSet palette = null;
			if (paletteFile != null)
			{
				palette = new PaletteSet(paletteFile);
			}

			// Select source files by random
			var srcFiles = new FileInfo[parts.Length];
			for (var i = 0; i < srcFiles.Length; i++)
			{
				var srcSet = src.GetParts(parts[i]);
				srcFiles[i] = srcSet[rand.Next(0, srcSet.Length)];
			}

			// Draw the layers together OMG
			Bitmap target = null;
			for (var i = 0; i < srcFiles.Length; i++)
			{
				ImageMerger.Merge(srcFiles[i], ref target, palette);
			}

			return target;
		}
	}
}

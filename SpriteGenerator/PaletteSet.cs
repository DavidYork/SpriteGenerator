using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SpriteGenerator
{
	// Used to create a mapping of colors to replacement colors
	// Files are groups of colors. See reference image.
	public class PaletteSet
	{
		Dictionary<Color, Color> _mappings = new Dictionary<Color, Color>();
		Random rand = new Random();

		public Color GetColor(Color src)
		{
			Color rv = src;
			if (_mappings.TryGetValue(src, out rv))
			{
				return rv;
			}
			else
			{
				return src;
			}
		}

		public PaletteSet(FileInfo palette)
		{
			var srcImg = new Bitmap(Image.FromFile(palette.FullName));
			int start = -1;
			int end = -1;
			for (var y = 0; y < srcImg.Height; y++)
			{
				// Look for groups
				if (start == -1)
				{
					if (srcImg.GetPixel(0, y).A > 0)
					{
						start = y;
						end = y;
					}
				}
				else
				{
					if (srcImg.GetPixel(0, y).A == 0)
					{
						readSet(srcImg, start, end);
						start = end = -1;
					}
					else
					{
						end = y;
					}
				}
			}
		}

		// Start and end are inclusive. End must be greater than start, otherwise no
		// possible substitutions can exist. First line is source pixels to read from,
		// all subsequent lines are replacement sets.
		void readSet(Bitmap src, int start, int end)
		{
			var idx = rand.Next(start + 1, end + 1);
			for (var x = 0; x < src.Width; x++)
			{
				var srcPixel = src.GetPixel(x, start);
				if (srcPixel.A == 0)
				{
					return;
				}
				var dstPixel = src.GetPixel(x, idx);
				_mappings.Add(srcPixel, dstPixel);
			}
		}
	}
}

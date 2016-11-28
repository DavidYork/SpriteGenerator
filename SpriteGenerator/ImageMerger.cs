using System.Drawing;
using System.IO;

namespace SpriteGenerator
{

	// Take a source image and a dest image and merge them together.
	// Essentially draw the source onto the target respecting transparency.
	// If target is null it will be created to the same size as src.
	// src and target of different sizes is not supported.
	public static class ImageMerger
	{
		public static void Merge(FileInfo src, ref Bitmap target, PaletteSet palette)
		{
			Bitmap img = new Bitmap(Image.FromFile(src.FullName));
			if (target == null)
			{
				target = new Bitmap(img.Width, img.Height, img.PixelFormat);
				var transPixel = Color.FromArgb(0, 0, 0, 0);

				for (var y = 0; y < target.Height; y++)
				{
					for (var x = 0; x < target.Width; x++)
					{
						target.SetPixel(x, y, transPixel);
					}
				}
			}

			for (var y = 0; y < img.Height; y++)
			{
				for (var x = 0; x < img.Width; x++)
				{
					var pixel = img.GetPixel(x, y);
					if (pixel.A > 0)
					{
						if (palette != null)
						{
							pixel = palette.GetColor(pixel);
						}
						target.SetPixel(x, y, pixel);
					}
				}
			}
		}
	}
}

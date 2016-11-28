using System.Drawing;
using System.IO;

namespace SpriteGenerator
{
	// Create a spritesheet of sprites of identical sizes.
	public class SpritesheetGen
	{
		int _x;
		int _y;
		int _padding;
		Bitmap _target;

		// Width and height are total size of image
		public SpritesheetGen(int width, int height, int padding)
		{
			_x = _y = _padding = padding;
			_target = new Bitmap(width, height);
		}

		// Returns true if there was room for the sprite, false if not
		public bool AddSprite(Bitmap src)
		{
			if (_x + src.Width > _target.Width + _padding)
			{
				_x = _padding;
				_y += _padding + src.Height;
			}
			if (_y + src.Height <= _target.Height - _padding)
			{
				for (var y = 0; y < src.Height; y++)
				{
					for (var x = 0; x < src.Width; x++)
					{
						var pixel = src.GetPixel(x, y);
						if (pixel.A > 0)
						{
							_target.SetPixel(x + _x, y + _y, pixel);
						}
					}
				}

				_x += (_padding + src.Width);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Save(string filename)
		{
			_target.Save(filename);
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;

namespace SpriteGenerator
{
	class MainClass
	{
		static string[] getParts()
		{
			List<string[]> validParts = new List<string[]>();
			validParts.Add(new string[] { "feet", "torso", "head", "helmet", "weapon", "shield" });
			validParts.Add(new string[] { "feet", "torso", "head", "helmet", "weapon" });
			validParts.Add(new string[] { "feet", "torso", "head", "hair", "weapon" });
			validParts.Add(new string[] { "feet", "torso", "head", "hair", "weapon", "shield" });

			validParts.Add(new string[] { "feet", "torso", "head", "helmet" });
			validParts.Add(new string[] { "feet", "torso", "head", "hair"});

			validParts.Add(new string[] { "feet", "torso", "head", "helmet", "bow" });
			validParts.Add(new string[] { "feet", "torso", "head", "hair", "bow" });

			var rand = new Random();
			return validParts[rand.Next(validParts.Count)];
		}

		public static void Main(string[] args)
		{
			DirectoryInfo inputDir = new DirectoryInfo("../../Reference/");
			DirectoryInfo outputDir = new DirectoryInfo("../../Dudes/");
			FileInfo paletteFile = new FileInfo(Path.Combine(inputDir.FullName, "colors.png"));

			int padding = 3;
			int spritesWide = 12;
			int spritesHigh = 8;
			int spriteSize = 24;
			int width = (spritesWide * spriteSize) + padding * (spritesWide + 1);
			int height = (spritesHigh * spriteSize) + padding * (spritesHigh + 1);
			SpritesheetGen spriteSheet = new SpritesheetGen(width, height, padding);

			for (int i = 0; i < spritesHigh * spritesWide; i++)
			{
				var parts = getParts();
				var name = string.Format("dude_{0}.png", i);
				var sprite = SpriteGenerator.Generate(inputDir, parts, paletteFile);

				spriteSheet.AddSprite(sprite);
				sprite.Save(Path.Combine(outputDir.FullName, name));
			}

			spriteSheet.Save(Path.Combine(outputDir.FullName, "allSprites.png"));

			Console.WriteLine("All done! Sprites were written to");
			Console.WriteLine(outputDir.FullName);
		}
	}
}

# SpriteGenerator
Generates sprites from a collection of parts and a palette.

## Usage
This was built with Visual Studio for Mac.
Open Solution, run project, it should read inputs from the `/Reference` folder and spit out output to `/Dudes` folder.
See `Program.cs`, function `Main` for more details about directory paths.

## Algorithm
1. Enumerate all files in source dir
2. Open palette BMP, read in palette info
3. Select palette info by random
4. Select one file from each set as ordered by specified layers
5. Draw all the layers on top of each other using selected palette info

## Palettes
Palettes have the following groups:

 * Primary Cloth
 * Skintone
 * Hair color
 * Secondary Cloth
 * Dark accent color (e.g. paint on shields)
 * Metal color
 * Wood color
 * Tertiary color
 * Leather
 * Gemstone

## More information
A full blog post explaining how this works and other fun details can be found at [http://davideyork.com/gengam-2016/](http://davideyork.com/gengam-2016/).
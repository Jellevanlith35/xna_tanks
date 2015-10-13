using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows_XNA_Tanks.Model.Tiles;

namespace Windows_XNA_Tanks.Model
{
    class Map
    {
        private List<Tile> _tiles;

        public Map()
        {
            _tiles = new List<Tile>();
        }

        public List<Tile> Tiles
        {
            get { return _tiles; }
            set { _tiles = value; }
        }

        public void GenerateMap(ContentManager content, GraphicsDeviceManager graphics, string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int counter = 0;
                    int lineCounter = 0;
                    int maxCharacters = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Length > maxCharacters)
                            maxCharacters = line.Length;

                        foreach (char character in line)
                        {
                            switch (character)
                            {
                                case '#':
                                    Wall wall = new Wall(content);
                                    wall.Point = new Point(32 * counter, 32 * lineCounter);
                                    wall.Rectangle = new Rectangle(wall.Point.X, wall.Point.Y, 32, 32);
                                    _tiles.Add(wall);
                                    counter++;
                                    break;
                                case '|':
                                    Street street = new Street(content);
                                    street.Point = new Point(32 * counter, 32 * lineCounter);
                                    street.Rectangle = new Rectangle(street.Point.X, street.Point.Y, 32, 32);
                                    _tiles.Add(street);
                                    counter++;
                                    break;
                                case ',':
                                    Grass grass = new Grass(content);
                                    grass.Point = new Point(32 * counter, 32 * lineCounter);
                                    grass.Rectangle = new Rectangle(grass.Point.X, grass.Point.Y, 32, 32);
                                    _tiles.Add(grass);
                                    counter++;
                                    break;
                            }
                        }
                        lineCounter++;
                        counter = 0;
                    }
                    graphics.PreferredBackBufferWidth = maxCharacters * 32;
                    graphics.PreferredBackBufferHeight = lineCounter * 32;
                    graphics.ApplyChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}

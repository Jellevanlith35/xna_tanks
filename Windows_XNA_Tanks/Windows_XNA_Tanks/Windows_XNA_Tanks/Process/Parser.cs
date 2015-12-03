using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows_XNA_Tanks.Model;
using Windows_XNA_Tanks.Model.Tiles;

namespace Windows_XNA_Tanks.Process
{
    class Parser
    {
        private Map map;
        private TankGame tankGame;
        private const int TILE_SIZE = 32;
        private int height;
        

        public Parser(TankGame tankGame)
        {
            this.tankGame = tankGame;
            height = 0;
        }

        public Map LoadMap(int mapId)
        {
            map = new Map();
            map.Width = 0;
            

            string filePath = String.Concat("..\\..\\..\\Worlds\\map", mapId, ".txt");
            string[] unparsedLines = File.ReadAllLines(filePath);
            List<Tile> previousLine = null;
            bool firstUnparsedLine = true;

            foreach (string unparsedLine in unparsedLines)
            {
                List<Tile> currentLine = parseLine(unparsedLine);

                if (currentLine.Count > map.Width)
                {
                    map.Width = currentLine.Count;
                }
                height = height + 1;

                // Set Origin
                if (firstUnparsedLine)
                {
                    map.Origin = currentLine[0];
                    firstUnparsedLine = false;
                }

                if (previousLine != null)
                {
                    linkParsedLines(previousLine, currentLine);
                }

                previousLine = currentLine;
            }

            map.Height = height;

            return map;
        }

        private List<Tile> parseLine(string unparsedLine)
        {
            List<Tile> parsedLine = new List<Tile>();
            Tile previousTile = null;

            for (int index = 0; index < unparsedLine.Length; index++)
            {
                Tile tile;
                Point point = new Point(index * TILE_SIZE, height * TILE_SIZE);

                switch (unparsedLine[index])
                {
                    case ',':
                        tile = new Grass(tankGame.grass, point);
                        break;
                    case '|':
                        tile = new Street(tankGame.street, point);
                        break;
                    case '#':
                        tile = new Wall(tankGame.wall, point);
                        break;
                    default:
                        throw new Exception();
                }

                if (previousTile != null)
                {
                    tile.Left = previousTile;
                    previousTile.Right = tile;
                }

                previousTile = tile;
                parsedLine.Add(tile);
            }

            return parsedLine;
        }

        private void linkParsedLines(List<Tile> firstLine, List<Tile> secondLine)
        {
            for (int index = 0; index < firstLine.Count; index++)
            {
                if (firstLine[index] != null && secondLine[index] != null)
                {
                    firstLine[index].Bottom = secondLine[index];
                    secondLine[index].Top = firstLine[index];
                }
            }
        }




    }
}

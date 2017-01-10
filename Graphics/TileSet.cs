using System;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreFramework.Game.Graphics
{
    public class TileSet
    {
        private string path;

        private Point tileSize;
        private Tile[] tiles;

        public TileSet(string path)
        {
            this.path = path;
        }

        public Tile Blank { get; private set; }
        public Point TileSize
        {
            get { return tileSize; }
        }
        public int Count
        {
            get { return tiles.Length; }
        }

        public Tile GetTile(int id)
        {
            return id < 0 || id >= tiles.Length ? tiles[0] : tiles[id];
        }
        

        public void Initialize(GraphicsDevice device)
        {
            Random rand = new Random();
            Color bg = Color.Transparent;
            bool isFill = true;
            string[] file = File.ReadAllLines(path + ".txt");
            string[] info = file[0].Split(' ');
            tileSize = new Point(Convert.ToInt32(info[0]), Convert.ToInt32(info[1]));
            if (info.Length == 2)
                isFill = false;
            else if (info.Length == 5)
                bg = new Color(Convert.ToByte(info[2]), Convert.ToByte(info[3]), Convert.ToByte(info[4]));
            else
                bg = new Color(Convert.ToByte(info[2]), Convert.ToByte(info[3]), Convert.ToByte(info[4]), Convert.ToByte(info[5]));

            //load tile set
            Texture2D tileMap = Texture2D.FromStream(device, File.OpenRead(path + ".png")); 
            //get tile set data
            Color[] colorMap = new Color[tileMap.Width * tileMap.Height]; 
            tileMap.GetData<Color>(colorMap);
            Point tileRes = new Point(tileMap.Width / tileSize.X, tileMap.Height / tileSize.Y);
            tiles = new Tile[tileRes.X * tileRes.Y];

            for (int i = 0; i < tiles.Length; i++)
            {
                Color[] buffer = new Color[tileSize.X * tileSize.Y];
                int x = i % tileRes.X, y = i / tileRes.X;
                Texture2D image = new Texture2D(device, tileSize.X, tileSize.Y);
                for (int a = 0; a < buffer.Length; a++)
                {
                    int px = a % tileSize.X, py = a / tileSize.X, index = (y * tileSize.Y + py) * tileMap.Width + x * tileSize.X + px;
                    Color bCol = colorMap[index];
                    if (isFill && bCol.Equals(bg))
                        buffer[py * tileSize.X + px] = Color.Transparent;
                    else
                        buffer[py * tileSize.X + px] = bCol;
                }
                image.SetData<Color>(buffer);
                tiles[i] = new Tile(this, i, image, buffer);
            }

            Blank = new Tile(this, -1, new Texture2D(device, tileSize.X, tileSize.Y), new Color[tileSize.X * tileSize.Y]);
        }
    }
}

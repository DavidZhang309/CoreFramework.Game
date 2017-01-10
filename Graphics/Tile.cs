using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreFramework.Game.Graphics
{
    public struct Tile
    {
        public Tile(TileSet tSet, int id, Texture2D image, Color[] rawData)
            : this()
        {
            Set = tSet;
            ID = id;
            Image = image;
            Rawdata = rawData;
        }
        public int ID
        {
            get;
            private set;
        }
        public TileSet Set
        {
            get;
            private set;
        }
        public Texture2D Image
        {
            get;
            private set;
        }
        public Color[] Rawdata
        {
            get;
            private set;
        }
    }
}

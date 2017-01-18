using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using CoreFramework.Game.Grid;

namespace CoreFramework.Game.Graphics.Grid
{
    public interface IGridTileProperties
    {
        Point TextureSize { get; }
        float TextureScale { get; }
        Texture2D GetTexture(Vector2 position);
    }

    public class TileSetGridGraphicsProperties : IGridTileProperties
    {
        protected IGridState state;
        protected TileSet set;

        public Point TextureSize { get; private set; }
        public float TextureScale { get; set; } = 1f;

        public TileSetGridGraphicsProperties(IGridState state, TileSet set)
        {
            this.set = set;
            TextureSize = set.TileSize;
            this.state = state;
        }
        
        public Texture2D GetTexture(Vector2 position)
        {
            return set.GetTile(state.GetTile(position)).Image;
        }
    }
}

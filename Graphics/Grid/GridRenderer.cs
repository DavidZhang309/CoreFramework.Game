using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using CoreFramework.Game.Graphics;

namespace CoreFramework.Game.Graphics.Grid
{
    public class GridRenderer : IRenderer
    {
        public IGridTileProperties Properties { get; private set; }
        protected UnitCalculator UnitX { get; private set; }
        protected UnitCalculator UnitY { get; private set; }

        public GridRenderer(IGridTileProperties properties)
        {
            Properties = properties;
            UnitX = new UnitCalculator() { UnitSize = (int)Math.Floor(Properties.TextureSize.X * Properties.TextureScale) };
            UnitY = new UnitCalculator() { UnitSize = (int)Math.Floor(Properties.TextureSize.Y * Properties.TextureScale) };
        }

        public void Render(GameTime time, SpriteBatch batch, Camera camera)
        {
            Vector2 cameraPosition = camera.Position - camera.Origin;
            
            Rectangle worldBounds = new Rectangle(
                (int)Math.Floor(cameraPosition.X / UnitX.UnitSize),
                (int)Math.Floor(cameraPosition.Y / UnitY.UnitSize),
                (int)Math.Ceiling(1f * camera.Screen.Bounds.Size.X / UnitX.UnitSize),
                (int)Math.Ceiling(1f * camera.Screen.Bounds.Size.Y / UnitY.UnitSize)
            );

            for (int unitX = worldBounds.Left; unitX <= worldBounds.Right; unitX++)
            {
                for(int unitY = worldBounds.Top; unitY <= worldBounds.Bottom; unitY++)
                {
                    Vector2 tileWorldPosition = new Vector2(unitX, unitY);

                    batch.Draw(Properties.GetTexture(tileWorldPosition),
                        tileWorldPosition * new Vector2(UnitX.UnitSize, UnitY.UnitSize) - cameraPosition,
                        null, Color.White, 0f, Vector2.Zero, Properties.TextureScale * camera.Scale, SpriteEffects.None, 0
                    );
                }
            }
        }
    }
}

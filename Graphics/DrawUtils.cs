using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using CoreFramework.Game;

namespace CoreFramework.Game.Graphics
{
    public class DrawHelper
    {
        public static Texture2D Dot { get; private set; }
        public static SpriteBatch Batch { get; set; }
        public static TileSet TextSet { get; set; }

        public static void Initalize(SpriteBatch batch)
        {
            Dot = new Texture2D(batch.GraphicsDevice, 1, 1);
            Dot.SetData<Color>(new Color[1] { Color.White });
            Batch = batch;
        }
        public static void UnloadResources()
        {
            if (Dot != null) Dot.Dispose();
        }

        public static void DrawLine(Vector2 pos1, Vector2 pos2, int width, Color color)
        {
            Batch.Draw(Dot, pos1, new Rectangle(0, 0, width, (int)MathExtLib.Distance(pos1, pos2)), color, (float)Math.Atan2(pos1.Y - pos2.Y, pos1.X - pos2.X) + MathHelper.PiOver2, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
        public static void DrawLine(Vector2 point, int length, double angle, int width, Color color)
        {
            angle -= MathHelper.PiOver2;
            Vector2 point2 = new Vector2(point.X + length * (float)Math.Cos(angle), point.Y + length * (float)Math.Sin(angle));
            DrawLine(point, point2, width, color);
        }
        public static void DrawBox(Vector2 pos1, Vector2 pos2, int width, Color color)
        {
            DrawLine(pos1, new Vector2(pos2.X, pos1.Y), width, color); // top line
            DrawLine(pos1, new Vector2(pos1.X, pos2.Y), width, color); // left line
            DrawLine(pos2, new Vector2(pos1.X, pos2.Y), width, color); // botton line
            DrawLine(pos2, new Vector2(pos2.X, pos1.Y), width, color); // right line
        }

        public static void DrawTextLine(TileSet set, string line, Vector2 position, Color color)
        {
            for (int i = 0; i < line.Length; i++)
                Batch.Draw(set.GetTile((int)line[i]).Image, new Vector2(position.X + i * set.TileSize.X, position.Y), color);
        }
        public static void DrawTextLine(string line, Vector2 position, Color color)
        {
            DrawTextLine(TextSet, line, position, color);
        }

        
    }
}


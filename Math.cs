using System;

using Microsoft.Xna.Framework;

namespace CoreFramework.Game
{
    class MathExtLib
    {
        public static double Distance(Vector2 pos1, Vector2 pos2)
        {
            return Math.Sqrt(Math.Pow(pos2.X - pos1.X, 2) + Math.Pow(pos2.Y - pos1.Y, 2));
        }
        public static Vector2 RotatePoint(Vector2 position, Vector2 origin, float angle)
        {
            Vector2 pos = Vector2.Subtract(position, origin);
            pos.X *= (float)Math.Cos(angle);
            pos.Y *= (float)Math.Sin(angle);
            return Vector2.Add(pos, origin);
        }
    }
}

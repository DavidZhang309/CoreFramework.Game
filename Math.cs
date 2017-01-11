using System;

using Microsoft.Xna.Framework;

namespace CoreFramework.Game
{
    public static class MathExtLib
    {
        public static double Distance(this Vector2 pos1, Vector2 pos2)
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

        /// <summary>
        /// Returns a vector with length and angle from origin
        /// </summary>
        /// <param name="length"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Vector2 CalculateVector(float length, float angle)
        {
            //angle -= MathHelper.PiOver2;
            return new Vector2(length * (float)Math.Cos(angle), length * (float)Math.Sin(angle));
        }
    }
}

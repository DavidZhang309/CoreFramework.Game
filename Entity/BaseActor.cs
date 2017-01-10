using System;
using Microsoft.Xna.Framework;

namespace CoreFramework.Game.Entity
{
    public abstract class BaseActor : IEntity
    {
        public int EntityID { get; protected set; }
        public Vector2 Position { get; protected set; }

        /// <summary>
        /// Represents the bounding rectangle with its origin relative to actor's position
        /// </summary>
        public Rectangle PhysicalBound { get; protected set; }

        /// <summary>
        /// transforms the rectangle relative to world
        /// </summary>
        /// <returns></returns>
        public Rectangle GetWorldBound()
        {
            Rectangle rect = PhysicalBound;
            rect.Offset(Position - new Vector2(rect.Width / 2f, rect.Height / 2f));
            return rect;
        }
    }
}

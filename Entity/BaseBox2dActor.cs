using System;

using Microsoft.Xna.Framework;

using Box2D.XNA;

namespace CoreFramework.Game.Entity
{
    public abstract class BaseBox2dActor : BaseActor
    {
        public float Rotation { get; protected set; }
    }
}

using Microsoft.Xna.Framework;

namespace CoreFramework.Game.Entity
{
    public interface IEntity
    {
        int EntityID { get; }
        Vector2 Position { get; }
    }
}

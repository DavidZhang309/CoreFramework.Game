using Microsoft.Xna.Framework;

namespace CoreFramework.Game.Grid
{
    public interface IGridState // : IState
    {
        int GetTile(Vector2 position);
    }
}

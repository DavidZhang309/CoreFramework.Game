using Microsoft.Xna.Framework.Graphics;

namespace CoreFramework.Game.Graphics
{
    public interface IRenderer
    {
        void Render(SpriteBatch batch, Camera camera);
    }
}

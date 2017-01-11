using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreFramework.Game.Graphics
{
    public interface IRenderer
    {
        void Render(GameTime time, SpriteBatch batch, Camera camera);
    }
}

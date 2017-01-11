using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreFramework.Game.Application
{
    public interface IApplication
    {
        void Load(SpriteBatch batch);
        void Update(GameTime time);
        void Draw(GameTime time);
    }
}

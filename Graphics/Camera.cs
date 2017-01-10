using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreFramework.Game.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class Camera
    {
        public Vector2 Origin { get; private set; }
        public Vector2 Position { get; set; }
        public float Scale { get; set; }

        public RenderTarget2D Screen { get; private set; }

        public Camera(SpriteBatch batch, int width, int height)
        {
            Scale = 1f;
            Screen = new RenderTarget2D(batch.GraphicsDevice, width, height);
            Origin = new Vector2(width, height) / 2f;
        }

        public Vector2 GetDrawOffset()
        {
            return -Position * Scale + Origin;
        }
        public Vector2 GetDrawPosition(Vector2 position)
        {
            return (position - Position) * Scale + Origin;
        }
        //tmp
        public Vector2 GetWorldPosition(Vector2 position)
        {
            return (position - Origin) / Scale + Position;
        }

        public void Move(int x, int y)
        {
            Position = Position + new Vector2(x, y);
        }
    }
}

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace CoreFramework.Game.Graphics
{
    /// <summary>
    /// 
    /// </summary>
    public class RenderSet
    {
        public List<IRenderer> Renderers { get; protected set; }

        public RenderSet()
        {
            Renderers = new List<IRenderer>();
        }

        public void Render(SpriteBatch batch, Camera camera)
        {
            foreach(IRenderer renderer in Renderers)
            {
                renderer.Render(batch, camera);
            }
        }
    }
}

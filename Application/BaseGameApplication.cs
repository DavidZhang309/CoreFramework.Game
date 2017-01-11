using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreFramework.Game.Application
{
    public abstract class BaseGameApplication : Microsoft.Xna.Framework.Game
    {
        public IApplication App { get; protected set; }
        protected SpriteBatch Batch { get; private set; }

        /// <summary>
        /// Note: Must be called after LoadContent (spritebatch needs to be initialized)
        /// </summary>
        /// <param name="application"></param>
        public void LoadApp(IApplication application)
        {
            App = application;
            App.Load(Batch);
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Batch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (App != null)
            {
                App.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (App != null)
            {
                App.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}

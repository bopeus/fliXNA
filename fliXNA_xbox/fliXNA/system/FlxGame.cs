using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace fliXNA_xbox
{
    public class FlxGame : Microsoft.Xna.Framework.Game
    {
        /// <summary>
        /// Required XNA stuff
        /// </summary>
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// FlxGame constructor takes in the initial state and resolution of the screen.
        /// </summary>
        /// <param name="State">The state you want to load</param>
        /// <param name="Width">The width of the screen</param>
        /// <param name="Height">The height of the screen</param>
        /// <param name="ContentRootDirectory">The directory of your content.  It is set automatically by default but you can change it if you want to.</param>
        public FlxGame(FlxState State, int Width = 1280, int Height = 720, string ContentRootDirectory = "Content") : base()
        {
            FlxG.state = State;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.ApplyChanges();
            Content.RootDirectory = ContentRootDirectory;
        }

        /// <summary>
        /// Required XNA initialization along with some FlxG initializations.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Basic FlxG inits that we need before we can call FlxG.init()
            FlxG.graphicsDevice = GraphicsDevice;
            FlxG.graphics = graphics;
            FlxG.content = Content;
            FlxG.spriteBatch = spriteBatch;
            FlxG.viewport = FlxG.graphicsDevice.Viewport;
            FlxG.width = graphics.PreferredBackBufferWidth;
            FlxG.height = graphics.PreferredBackBufferHeight;
            
            FlxG.init();
        }

        /// <summary>
        /// Update FlxG which updates important mechanics such as cameras and time elapsed.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            FlxG.update(gameTime);
        }

        /// <summary>
        /// Draw everything - mainly the state and all of its objects.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            FlxG.state.draw();
        }
    }
}
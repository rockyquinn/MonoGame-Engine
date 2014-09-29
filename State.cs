using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoGame_Game_Engine
{
    abstract class State
    {
        /// <summary>
        /// Decides if this is the state that will be drawn. 
        /// Only one state can be drawn at a time.
        /// </summary>
        private bool isCurrent;
        /// <summary>
        /// Contains all items to be drawn.
        /// </summary>
        private Dictionary<Vector2,Texture2D> contents;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="current">(bool)Whether or not this will be drawn</param>
        public State(bool current)
        {
            isCurrent = current;
            contents = new Dictionary<Vector2, Texture2D>();
        }


        /// <summary>
        /// Draws everything within the contents
        /// </summary>
        /// <param name="spriteBatch">Used to draw things to the screen</param>
        public void draw(SpriteBatch spriteBatch)
        {
            if (!isCurrent)
                return;
            foreach (Vector2 key in contents.Keys)
            {
                spriteBatch.Draw(contents[key], key, Color.White);
            }
        }


        /// <summary>
        /// Adds an item to the dictionary of things to be drawn
        /// </summary>
        /// <param name="place">(Vector2) Location of item</param>
        /// <param name="item">(Texture2D) item to be drawn</param>
        public void add(Vector2 place, Texture2D item)
        {
            contents.Add(place, item);
        }
    }
}

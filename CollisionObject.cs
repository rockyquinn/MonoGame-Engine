using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_Game_Engine
{
        /// <summary>
        /// Keeps track of all objects that can have collisions
        /// </summary>
        public abstract class CollisionObject
        {
            /// <summary>
            /// The position of this object
            /// </summary>
            public Vector2 position;

            /// <summary>
            /// The Child objects Type
            /// </summary>
            private String type;

            /// <summary>
            /// True if the object can be collided with everything
            /// </summary>
            public bool isCollidable = true;

            /// <summary>
            /// True if object is moving left
            /// </summary>
            public bool facingLeft = false;

            /// <summary>
            /// True if object is moving right
            /// </summary>
            public bool facingRight = false;

            /// <summary>
            /// True if object is moving back
            /// </summary>
            public bool facingBack = false;

            /// <summary>
            /// The x coordinate of the object
            /// </summary>
            public int x;

            /// <summary>
            /// The y coordinate of the object
            /// </summary>
            public int y;

            /// <summary>
            /// the object's width
            /// </summary>
            public int width;

            /// <summary>
            /// The object's height
            /// </summary>
            public int height;

            /// <summary>
            /// Animation counter
            /// </summary>
            private int aniCount = 0;

            /// <summary>
            /// The maximum value of ani count;
            /// if(aniCount == maxAniCount)
            ///     aniCount = 0;
            /// </summary>
            private int maxAniCount;

            /// <summary>
            /// If true, animation will continue
            /// </summary>
            public bool animate;

            /// <summary>
            /// To hold all of the images used in animating this object.
            /// </summary>
            private Dictionary<String, Texture2D> animations;

            /// <summary>
            /// How fast an image will be animated
            ///   0  ===> 100
            /// Fast ===> Slow
            /// </summary>
            public int buffer = 5;


            /// <summary>
            /// Constructor for objects that have animations
            /// </summary>
            /// <param name="typ">child class name</param>
            /// <param name="nx">x position</param>
            /// <param name="ny">y position</param>
            /// <param name="anims">images for the animations</param>
            /// <param name="still">standing image</param>
            /// <param name="maxAni">Maximum animation counter constant</param>
            public CollisionObject(String typ, int nx, int ny, Dictionary<String, Texture2D> anims, Texture2D still, int maxAni)
            {
                type = typ;
                x = nx;
                y = ny;
                position = new Vector2(nx, ny);
                animations = anims;
                animations.Add("stand", still);
                maxAniCount = maxAni;
                facingLeft = true;
            }

            /// <summary>
            /// Constructor for objects that don't have animations
            /// </summary>
            /// <param name="type">child class name</param>
            /// <param name="nx">x position</param>
            /// <param name="ny">y position</param>
            /// <param name="image">the image to display for this object</param>
            public CollisionObject(String typ, int nx, int ny, Texture2D image, int maxAni)
            {
                type = typ;
                x = nx;
                y = ny;
                position = new Vector2(nx, ny);
                width = image.Width;
                height = image.Height;
                animations = new Dictionary<String, Texture2D>();
                animations.Add("stand", image);
                maxAniCount = maxAni;
                facingLeft = true;
            }

            /// <summary>
            /// Constructor for objects that need an image to be initialized after declaration
            /// </summary>
            /// <param name="type">child class name</param>
            /// <param name="nx">x position</param>
            /// <param name="ny">y position</param>
            public CollisionObject(String typ, int nx, int ny, int maxAni)
            {
                type = typ;
                x = nx;
                y = ny;
                position = new Vector2(nx, ny);
                animations = new Dictionary<String, Texture2D>();
                maxAniCount = maxAni;
                facingLeft = true;
            }

            /// <summary>
            /// Sets the standing image
            /// </summary>
            /// <param name="still">new image</param>
            public void setStand(Texture2D still)
            {
                animations["stand"] = still;
            }

            /// <summary>
            /// Sets height
            /// </summary>
            /// <param name="nh">new height</param>
            public void setHeight(int nh) { height = nh; }
            /// <summary>
            /// Gets height
            /// </summary>
            /// <returns>(int) height</returns>
            public int getHeight() { return height; }

            /// <summary>
            /// Sets width
            /// </summary>
            /// <param name="nw">new width</param>
            public void setWidth(int nw) { width = nw; }
            /// <summary>
            /// Gets width
            /// </summary>
            /// <returns>(int) width</returns>
            public int getWidth() { return width; }


            /// <summary>
            /// Gets the Vector2 representation of the position
            /// </summary>
            /// <returns>(Vector2) position</returns>
            public Vector2 getPosition() { return position; }

            /// <summary>
            /// Sets the position
            /// </summary>
            /// <param name="nx">new x</param>
            /// <param name="ny">new y</param>
            public void setPosition(int nx, int ny)
            {
                x = nx;
                y = ny;
                position = new Vector2(nx, ny);
            }

            /// <summary>
            /// Gets standing animation image
            /// </summary>
            /// <returns>(Texture2D) image</returns>
            public Texture2D getStandingImage()
            {
                return animations["stand"];
            }

            /// <summary>
            /// Sets the right facing animations list
            /// </summary>
            /// <param name="dict">Dictionary of Texture2D objects linked to strings</param>
            public void setAnimations(Dictionary<String, Texture2D> dict)
            {
                animations = dict;
            }

            /// <summary>
            /// Draws the images
            /// </summary>
            /// <param name="spriteBatch">a SpriteBatch object</param>
            public void draw(SpriteBatch spriteBatch)
            {
                if (aniCount == maxAniCount)
                    aniCount = 0;

                if (!animate)
                    spriteBatch.Draw(animations["stand"], position, Color.White);
                else
                {
                    String temp;
                    if (facingRight)
                    {
                        temp = "right" + aniCount;
                    }
                    else if (facingLeft)
                    {
                        temp = "left" + aniCount;
                    }
                    else if (facingBack)
                    {
                        temp = "back" + aniCount;
                    }
                    else
                    {
                        temp = "front" + aniCount;
                    }
                    aniCount++;
                    spriteBatch.Draw(animations[temp], position, Color.White);
                }
            }


            /// <summary>
            /// Compares the positions of object o compared
            /// to the calling object
            /// </summary>
            /// <param name="o">object used for comparison</param>
            public bool compareTo(CollisionObject o)
            {
                if (this.x + this.width >= o.x &&
                    this.x <= o.x + o.width &&
                    this.y + this.height >= o.y &&
                    this.y <= o.y + o.height)
                {
                    return true;
                }
                return false;
            }
    }

}

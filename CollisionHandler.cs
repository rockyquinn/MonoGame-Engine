using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame_Game_Engine
{
    class CollisionHandler
    {
        public static int timer = 0;


        public static Dictionary<String, CollisionObject> COLLISION_OBJECTS;


        /// <summary>
        /// Static method to be called in every frame.
        /// Currently:
        ///     1) Adds to the timer
        ///     2) Calls checkCollisions()
        /// </summary>
        public static void update()
        {
            timer++;
            checkCollisions();
        }


        /// <summary>
        /// Searches for collisions throughout all of the 
        /// CollisionObjects
        /// </summary>
        private static void checkCollisions()
        {
            if (MainState.isCurrent)
            {
            }
            else if (GameState.isCurrent)
            {
            }
            else if (OptionState.isCurrent)
            {
            }
        }


        /// <summary>
        /// Adds a new CollisionObject to the list
        /// </summary>
        /// <param name="key">String to represent the object</param>
        /// <param name="nObj">CollisionObject to be placed in list</param>
        public static void add(String key, CollisionObject nObj)
        {
            COLLISION_OBJECTS.Add(key, nObj);
        }
    }
}

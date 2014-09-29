using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame_Game_Engine
{
    class CollisionHandler
    {
        public static int timer = 0;


        public static Dictionary<String, CollisionObject> COLLISION_OBJECTS = new Dictionary<string,CollisionObject>();


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
            foreach(String key1 in COLLISION_OBJECTS.Keys)
            {
                foreach (String key2 in COLLISION_OBJECTS.Keys)
                {
                    if (COLLISION_OBJECTS[key1].Equals(COLLISION_OBJECTS[key2]))//Comparing same object\\
                        continue;
                    if(COLLISION_OBJECTS[key1].compareTo(COLLISION_OBJECTS[key2]) &&
                            COLLISION_OBJECTS[key1].isCollidable                  &&
                            COLLISION_OBJECTS[key2].isCollidable)
                    {//Collision Happened\\
                        COLLISION_OBJECTS[key1].collision(COLLISION_OBJECTS[key2].position);
                        COLLISION_OBJECTS[key2].collision(COLLISION_OBJECTS[key1].position);
                    }
                }
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

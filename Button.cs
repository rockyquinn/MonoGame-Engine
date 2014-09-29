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
    /// CollisionObject that keeps track of Buttons
    /// </summary>
    class Button : CollisionObject
    {
        /// <summary>
        /// Determines what state will be changeed to when clicked
        /// </summary>
        private State stateChange;
        /// <summary>
        /// Boolean representing whether or not button is selected.
        /// </summary>
        private bool selected;
        /// <summary>
        /// Boolean representing whether or not button is clicked.
        /// </summary>
        private bool clicked;

        /// <summary>
        /// Constructor for a Button.
        /// </summary>
        /// <param name="nx">(int) X position</param>
        /// <param name="ny">(int) Y position</param>
        /// <param name="w">(int) Width</param>
        /// <param name="h">(int) Height</param>
        /// <param name="state">(String) State to change to if button is clicked</param>
        /// <param name="im">(Texture2D) Image</param>
        public Button(int nx, int ny, int w, int h, State state, Texture2D im)
            : base("Button", nx, ny, im, 1)
        {
            selected = false;
            clicked = false;
            stateChange = state;
        }

        /// <summary>
        /// Returns whether the button is selected
        /// </summary>
        /// <returns>(bool) selected</returns>
        public bool isSelected()
        {
            return selected;
        }

        /// <summary>
        /// Forces the button to be selected
        /// </summary>
        public void forceSelect()
        {
            selected = true;
        }

        /// <summary>
        /// Makes the button unselected
        /// </summary>
        public void unselect()
        {
            selected = false;
        }

        /// <summary>
        /// Sets clicked to true
        /// </summary>
        /// <returns>(String) stateChange</returns>
        public State click()
        {
            clicked = true;
            return stateChange;
        }

        /// <summary>
        /// Return a boolean based on whether or not this button has been clicked.
        /// </summary>
        /// <returns>(bool) clicked</returns>
        public bool isClicked()
        {
            return clicked;
        }
    }
}

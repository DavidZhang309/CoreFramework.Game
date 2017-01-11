using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CoreFramework.Game.Controls
{
    public enum MInputType { LB, MB, RB, SCROLL, XB1, XB2, Position };
    public class MouseEventArgs : EventArgs
    {
        private EventMouse mouse;

        public MouseEventArgs(EventMouse Mouse)
        {
            mouse = Mouse;
        }

        public EventMouse Event
        {
            get { return mouse; }
        }
    }
    /// <summary>
    /// Provides a event based mouse input using MouseState 
    /// </summary>
    public class EventMouse
    {
        private MouseState state;
        private MInputType inputType;
        private object delta;

        public EventMouse(MouseState State, MInputType InputType, object Delta)
        {
            state = State;
            inputType = InputType;
            delta = Delta;
        }

        public MouseState State
        {
            get { return state; }
        }
        /// <summary>
        /// The type of input of the event
        /// </summary>
        public MInputType Input
        {
            get { return inputType; }
        }
        /// <summary>
        /// Point if a change in X and/or Y, as (dx, dy)
        /// int if scrolling, as (dx)
        /// bool for button
        /// </summary>
        public object Delta
        {
            get { return delta; }
        }
    }
    public class MouseComponent
    {
        MouseState lastState;

        public MouseState RawState { get; private set; }

        public event EventHandler<MouseEventArgs> MouseEvent;

        public void Initialize()
        {
            lastState = Mouse.GetState();
        }

        public void Update(GameTime time)
        {
            MouseState current = Mouse.GetState();
            RawState = current;
            EventMouse currentEvent = null;

            if (lastState.LeftButton != current.LeftButton)
                currentEvent = new EventMouse(current, MInputType.LB, current.LeftButton == ButtonState.Pressed);
            if (lastState.MiddleButton != current.MiddleButton)
                currentEvent = new EventMouse(current, MInputType.MB, current.MiddleButton == ButtonState.Pressed);
            if (lastState.RightButton != current.RightButton)
                currentEvent = new EventMouse(current, MInputType.RB, current.RightButton == ButtonState.Pressed);
            if (lastState.XButton1 != current.XButton1)
                currentEvent = new EventMouse(current, MInputType.XB1, current.XButton1 == ButtonState.Pressed);
            if (lastState.XButton2 != current.XButton2)
                currentEvent = new EventMouse(current, MInputType.XB2, current.XButton2 == ButtonState.Pressed);
            if (lastState.ScrollWheelValue != current.ScrollWheelValue)
                currentEvent = new EventMouse(current, MInputType.SCROLL, current.ScrollWheelValue - lastState.ScrollWheelValue);
            if (lastState.X != current.X || lastState.Y != current.Y)
                currentEvent = new EventMouse(current, MInputType.Position, new Point(current.X - lastState.X, current.Y - lastState.Y));
            if (currentEvent != null && MouseEvent != null)
            {
                MouseEvent(this, new MouseEventArgs(currentEvent));
            }

            lastState = current;
        }
    }
}

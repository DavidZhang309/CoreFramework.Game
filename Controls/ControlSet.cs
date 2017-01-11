using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CoreFramework.Game.Controls
{
    public interface IControl
    {
        bool ControlEnabled { get; set; }

        void ControlUpdate(GameTime time, MouseState mouse, KeyboardState keyboard);
    }
    public interface IEventControl
    {
        void OnMouseEvent(object sender, MouseEventArgs e);
        void OnKeyDown(object sender, KeyEventArgs e);
        void OnKeyUp(object sender, KeyEventArgs e);
    }

    public class ControlSet
    {
        private MouseComponent mouse;
        private KeyBoardComponent keyboard;

        public List<IControl> Controls { get; private set; }

        public ControlSet()
        {
            mouse = new MouseComponent();
            mouse.MouseEvent += Mouse_MouseEvent;
            keyboard = new KeyBoardComponent();
            keyboard.OnKeyDown += Keyboard_OnKeyDown;
            keyboard.OnKeyUp += Keyboard_OnKeyUp;

            Controls = new List<IControl>();
        }
        
        //Events
        private void Keyboard_OnKeyDown(object sender, KeyEventArgs e)
        {
            foreach(IControl control in Controls)
            {
                IEventControl eventControl = control as IEventControl;
                if(eventControl != null && control.ControlEnabled)
                {
                    eventControl.OnKeyDown(sender, e);
                }
            }
        }
        private void Keyboard_OnKeyUp(object sender, KeyEventArgs e)
        {
            foreach (IControl control in Controls)
            {
                IEventControl eventControl = control as IEventControl;
                if (eventControl != null && control.ControlEnabled)
                {
                    eventControl.OnKeyUp(sender, e);
                }
            }
        }
        private void Mouse_MouseEvent(object sender, MouseEventArgs e)
        {
            foreach (IControl control in Controls)
            {
                IEventControl eventControl = control as IEventControl;
                if (eventControl != null && control.ControlEnabled)
                {
                    eventControl.OnMouseEvent(sender, e);
                }
            }
        }
        
        //API
        public void Update(GameTime time)
        {
            mouse.Update(time);
            keyboard.Update(time);

            foreach(IControl control in Controls)
            {
                if (control.ControlEnabled)
                {
                    control.ControlUpdate(time, mouse.RawState, keyboard.RawState);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CoreFramework.Game.Controls
{
    public class KeyEventArgs : EventArgs
    {
        public KeyEventArgs(KeyboardState state, Keys[] events)
        {
            State = state;
            ChangedKeys = events;
        }

        public KeyboardState State { get; private set; }
        public Keys[] ChangedKeys { get; private set; }
        public int Count
        {
            get { return ChangedKeys.Length; }
        }
    }
    public class KeyBoardComponent
    {
        KeyboardState lastState;
        Keys[] lastPressed;

        public KeyboardState RawState { get; private set; }
        public event EventHandler<KeyEventArgs> OnKeyDown;
        public event EventHandler<KeyEventArgs> OnKeyUp;

        public void Initialize()
        {
            this.lastState = Keyboard.GetState();
            lastPressed = lastState.GetPressedKeys();
        }

        private bool Contains(Keys[] keys, Keys key)
        {
            for (int i = 0; i < keys.Length; i++)
                if (keys[i] == key)
                    return true;
            return false;
        }
        public void Update(GameTime time)
        {
            Queue<Keys> changed = new Queue<Keys>();

            KeyboardState current = Keyboard.GetState();
            RawState = current;

            Keys[] pressed = current.GetPressedKeys();

            //tmp: fix missing change
            if (lastPressed == null)
            {
                lastPressed = pressed;
                return;
            }

            foreach (Keys key in pressed)
                if (!Contains(lastPressed, key))
                    changed.Enqueue(key);

            if (changed.Count != 0 && OnKeyDown != null)
            {
                Keys[] events = new Keys[changed.Count];
                for (int i = 0; i < events.Length; i++)
                {
                    events[i] = changed.Dequeue();
                }
                OnKeyDown(this, new KeyEventArgs(current, events));
            }

            foreach (Keys key in lastPressed)
                if (!Contains(pressed, key))
                    changed.Enqueue(key);

            if (changed.Count != 0 && OnKeyUp != null)
            {
                Keys[] events = new Keys[changed.Count];
                for (int i = 0; i < events.Length; i++)
                {
                    events[i] = changed.Dequeue();
                }
                OnKeyUp(this, new KeyEventArgs(current, events));
            }

            lastState = current;
            lastPressed = pressed;
        }
    }
}

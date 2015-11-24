using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{

    public enum InputMode { Controler, Keyboard, KeyMouse }
    public enum MouseButton { Left, Middle, Right }

    public class InputHelper
    {

        private InputMode inputDevice;
        private GamePadState currentControlerState, previousControlerState;
        private KeyboardState currentKeyboardState, previousKeyboardState;
        private MouseState currentMouseState, previousMouseState;

        public InputHelper(InputMode inputDevice = InputMode.KeyMouse)
        {
            this.inputDevice = inputDevice;

            currentControlerState = GamePad.GetState(PlayerIndex.One);
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();
        }

        public void Update()
        {
            previousControlerState = currentControlerState;
            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;

            currentControlerState = GamePad.GetState(PlayerIndex.One);
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();
        }

        public bool IsButtonDown(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k);
        }

        public bool IsButtonPresed(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
        }

        public bool IsMouseButtonDown(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left: return currentMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Middle: return currentMouseState.MiddleButton == ButtonState.Pressed;
                case MouseButton.Right: return currentMouseState.RightButton == ButtonState.Pressed;
                default: return false;
            }
        }

        public bool IsMouseButtonPresed(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left: return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
                case MouseButton.Middle: return currentMouseState.MiddleButton == ButtonState.Pressed && previousMouseState.MiddleButton == ButtonState.Released;
                case MouseButton.Right: return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
                default: return false;
            }
        }

        public bool IsControlerButtonDown(Buttons b)
        {
            return currentControlerState.IsButtonDown(b);
        }

        public bool IsControlerButtonPresed(Buttons b)
        {
            return currentControlerState.IsButtonDown(b) && previousControlerState.IsButtonUp(b);
        }

        public Vector2 MovementVector
        {
            get
            {
                Vector2 moveVector = Vector2.Zero;
                switch (inputDevice)
                {
                    case InputMode.Controler:

                        if (currentControlerState.IsButtonDown(Buttons.DPadUp)) { moveVector.Y++; }
                        if (currentControlerState.IsButtonDown(Buttons.DPadDown)) { moveVector.Y--; }
                        if (currentControlerState.IsButtonDown(Buttons.DPadLeft)) { moveVector.X--; }
                        if (currentControlerState.IsButtonDown(Buttons.DPadRight)) { moveVector.X++; }

                        if (moveVector != Vector2.Zero) { return Vector2.Normalize(moveVector); }
                        else { return Vector2.Normalize(currentControlerState.ThumbSticks.Left); }

                    case InputMode.Keyboard:

                        if (currentKeyboardState.IsKeyDown(Keys.A)) { moveVector.X--; }
                        if (currentKeyboardState.IsKeyDown(Keys.D)) { moveVector.X++; }
                        if (currentKeyboardState.IsKeyDown(Keys.W)) { moveVector.Y++; }
                        if (currentKeyboardState.IsKeyDown(Keys.S)) { moveVector.Y--; }

                        return Vector2.Normalize(moveVector);

                    case InputMode.KeyMouse:

                        if (currentKeyboardState.IsKeyDown(Keys.A) || currentKeyboardState.IsKeyDown(Keys.Left)) { moveVector.X--; }
                        if (currentKeyboardState.IsKeyDown(Keys.D) || currentKeyboardState.IsKeyDown(Keys.Right)) { moveVector.X++; }
                        if (currentKeyboardState.IsKeyDown(Keys.W) || currentKeyboardState.IsKeyDown(Keys.Up)) { moveVector.Y++; }
                        if (currentKeyboardState.IsKeyDown(Keys.S) || currentKeyboardState.IsKeyDown(Keys.Down)) { moveVector.Y--; }

                        return Vector2.Normalize(moveVector);

                    default: return moveVector;
                }
            }
        }

        public Vector2 CameraVector // TODO: Decide wether camera changes for jaw and pitch should be taken lose or together (i.e. going faster on one axis slows movement along the other axis)
        {
            get
            {
                switch (inputDevice)
                {
                    case InputMode.Controler: return Vector2.Normalize(currentControlerState.ThumbSticks.Right);
                    case InputMode.Keyboard:

                        Vector2 cameraVector = Vector2.Zero;
                        if (currentKeyboardState.IsKeyDown(Keys.Left)) { cameraVector.X--; }
                        if (currentKeyboardState.IsKeyDown(Keys.Right)) { cameraVector.X++; }
                        if (currentKeyboardState.IsKeyDown(Keys.Up)) { cameraVector.Y++; }
                        if (currentKeyboardState.IsKeyDown(Keys.Down)) { cameraVector.Y--; }

                        return Vector2.Normalize(cameraVector);

                    case InputMode.KeyMouse: return Vector2.Normalize(new Vector2(currentMouseState.X - previousMouseState.X, currentMouseState.X - previousMouseState.X));
                    default: return Vector2.Zero;
                }
            }
        }

        public Vector2 MousePosition
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }

        public InputMode InputDevice
        {
            get { return inputDevice; }
            set { inputDevice = value; }
        }

    }
}

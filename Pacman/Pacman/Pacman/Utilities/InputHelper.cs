using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{

    public enum InputMode { KeyMouse, Controler }

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

        public Vector2 MovementVector
        {
            get
            {
                Vector2 moveVector = Vector2.Zero;
                if (inputDevice == InputMode.Controler)
                {
                    if (currentControlerState.IsButtonDown(Buttons.DPadUp)) { moveVector.Y++; }
                    if (currentControlerState.IsButtonDown(Buttons.DPadDown)) { moveVector.Y--; }
                    if (currentControlerState.IsButtonDown(Buttons.DPadLeft)) { moveVector.X--; }
                    if (currentControlerState.IsButtonDown(Buttons.DPadRight)) { moveVector.X++; }

                    if (moveVector != Vector2.Zero) { return Vector2.Normalize(moveVector); }
                    else { return Vector2.Normalize(currentControlerState.ThumbSticks.Left); }
                }
                else
                {
                    if (currentKeyboardState.IsKeyDown(Keys.A)) { moveVector.X--; }
                    if (currentKeyboardState.IsKeyDown(Keys.D)) { moveVector.X++; }
                    if (currentKeyboardState.IsKeyDown(Keys.W)) { moveVector.Y++; }
                    if (currentKeyboardState.IsKeyDown(Keys.S)) { moveVector.Y--; }

                    return Vector2.Normalize(moveVector);
                }
            }
        }

        public Vector2 CameraVector
        {
            get
            {
                if (inputDevice == InputMode.Controler)
                {
                    return Vector2.Normalize(currentControlerState.ThumbSticks.Right);
                }
                else
                {
                    Vector2 cameraVector = Vector2.Zero;
                    if (currentKeyboardState.IsKeyDown(Keys.Left)) { cameraVector.X--; }
                    if (currentKeyboardState.IsKeyDown(Keys.Right)) { cameraVector.X++; }
                    if (currentKeyboardState.IsKeyDown(Keys.Up)) { cameraVector.Y++; }
                    if (currentKeyboardState.IsKeyDown(Keys.Down)) { cameraVector.Y--; }

                    return Vector2.Normalize(cameraVector);
                }
            }
        }

        public InputMode InputDevice
        {
            get { return inputDevice; }
        }

    }
}

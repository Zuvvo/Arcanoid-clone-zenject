using UnityEngine;
using Zenject;

namespace Arkanoid.Player
{
    public class PlayerInputHandler : ITickable
    {
        private readonly PlayerInputState _inputState;

        public PlayerInputHandler(PlayerInputState inputState)
        {
            _inputState = inputState;
        }

        public void Tick()
        {
            _inputState.MouseHorizontalPosition = Input.mousePosition.x;
          //  Debug.Log(_inputState.MouseHorizontalPosition);
        }
    }
}
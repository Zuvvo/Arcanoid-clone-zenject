using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : IFixedTickable
    {
        private readonly PlayerInputState _inputState;

        public PlayerMovement(PlayerInputState playerInputState)
        {
            _inputState = playerInputState;
        }


        public void FixedTick()
        {
            float mousePost = _inputState.MouseHorizontalPosition;
        }

        [System.Serializable]
        public class Settings
        {
            public float MoveSpeed;
        }
    }
}
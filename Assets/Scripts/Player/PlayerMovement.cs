using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Arkanoid.Level;
using System.Linq;

namespace Arkanoid.Player
{
    public class PlayerMovement : IFixedTickable
    {
        private readonly PlayerInputState _inputState;
        private readonly PlayerModel _playerModel;
        private readonly float _minX;
        private readonly float _maxX;
        private readonly Camera _cam;

        private float _playerSizeMultiplierForWallCollision = 1.4f;

        public PlayerMovement(PlayerInputState playerInputState, LevelFacade levelFacade, PlayerModel playerModel)
        {
            _inputState = playerInputState;
            _playerModel = playerModel;
            _cam = Camera.main;

            _minX = levelFacade.GetXMinWallBorders();
            _maxX = levelFacade.GetXMaxWallBorders();
        }

        public void FixedTick()
        {
            float playerSizeOffset = _playerModel.GetPlayerWidthForWallCollision() * _playerSizeMultiplierForWallCollision / 2;
            float minScreenX = _cam.WorldToViewportPoint(new Vector3(_minX + playerSizeOffset, 0, 0)).x * Screen.width;
            float maxScreenX = _cam.WorldToViewportPoint(new Vector3(_maxX - playerSizeOffset, 0, 0)).x * Screen.width;
            float mousePos = Mathf.Clamp(_inputState.MouseHorizontalPosition, minScreenX, maxScreenX);
            Vector2 vec = _cam.ScreenToWorldPoint(new Vector3(mousePos, 0, 0));
            _playerModel.SetXPosition(vec.x);
        }

        [System.Serializable]
        public class Settings
        {
            public float MoveSpeed;
        }
    }
}
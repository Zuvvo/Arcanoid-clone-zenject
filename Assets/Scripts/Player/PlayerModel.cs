using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        private readonly Rigidbody2D _rigidBody;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly BoxCollider2D _boxCollider2D;

        public PlayerModel(Rigidbody2D rigidbody2D, SpriteRenderer spriteRenderer, BoxCollider2D boxCollider2D)
        {
            Debug.Log("Player model constructor");
            _rigidBody = rigidbody2D;
            _spriteRenderer = spriteRenderer;
            _boxCollider2D = boxCollider2D;
        }

        public float GetPlayerWidthForWallCollision()
        {
            return _boxCollider2D.bounds.size.x;
        }

        public void SetXPosition(float x)
        {
            _rigidBody.MovePosition(new Vector2(x, _rigidBody.transform.position.y));
        }
    }
}
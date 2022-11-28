using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        public Rigidbody2D Rigidbody { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }
        public BoxCollider2D BoxCollider2D { get; private set; }

        public PlayerModel(Rigidbody2D rigidbody2D, SpriteRenderer spriteRenderer, BoxCollider2D boxCollider2D)
        {
            Rigidbody = rigidbody2D;
            SpriteRenderer = spriteRenderer;
            BoxCollider2D = boxCollider2D;
        }

        public float GetPlayerWidthForWallCollision()
        {
            return BoxCollider2D.bounds.size.x;
        }

        public void SetXPosition(float x)
        {
            Rigidbody.MovePosition(new Vector2(x, Rigidbody.transform.position.y));
        }
    }
}
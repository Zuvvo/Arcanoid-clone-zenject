using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerBounce : MonoBehaviour
    {
        [Inject] private readonly PlayerModel _playerModel;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(TagConstants.BallTag))
            {
                float playerCenterToBallDistance = collision.transform.position.x - transform.position.x;
                collision.rigidbody.velocity = new Vector2(playerCenterToBallDistance / _playerModel.BoxCollider2D.bounds.size.x, 1).normalized;
            }
        }
    }
}
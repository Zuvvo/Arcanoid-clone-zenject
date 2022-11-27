using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkanoid.GameElements
{
    public class BallMovement : ITickable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;

        public BallMovement(Rigidbody2D rigidbody, float speed)
        {
            Debug.Log("ball movement constructor");
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Tick()
        {
            Debug.Log("tick call");
            _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        }

    }
}
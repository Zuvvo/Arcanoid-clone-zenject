using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkanoid.GameElements
{
    public class Ball : MonoBehaviour, IPoolable<IMemoryPool>
    {
        public void OnDespawned()
        {
            throw new System.NotImplementedException();
        }

        public void OnSpawned(IMemoryPool pool)
        {

        }

        public class Factory : PlaceholderFactory<Ball>
        {
        }
    }
}
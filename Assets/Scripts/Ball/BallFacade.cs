using System;
using UnityEngine;
using Zenject;


namespace Arkanoid.GameElements
{
    public class BallFacade : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {

        private IMemoryPool _pool;
        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        public class Factory : PlaceholderFactory<BallFacade>
        {
        }
    }

}
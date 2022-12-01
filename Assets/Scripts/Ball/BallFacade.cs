using System;
using UnityEngine;
using Zenject;
using Arkanoid.Save;


namespace Arkanoid.GameElements
{
    public class BallFacade : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        [Inject] private BallInstaller.Settings _settings;
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

        public BallData GetNewBallSaveData()
        {
            BallData data = new BallData()
            {
                BallMoveVectorX = _settings.Rigidbody.velocity.x,
                BallMoveVectorY = _settings.Rigidbody.velocity.y,
                BallPositionX = transform.position.x,
                BallPositionY = transform.position.y,
            };

            return data;
        }

        public class Factory : PlaceholderFactory<BallFacade>
        {
        }
    }
}
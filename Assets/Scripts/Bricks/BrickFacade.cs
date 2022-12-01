using System;
using UnityEngine;
using Zenject;

namespace Arkanoid.GameElements
{
    public class BrickFacade : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        public int Id { get; set; }
        public BrickInstaller.Settings Settings => _settings;
        [Inject] private readonly BrickInstaller.Settings _settings;

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
        public class Factory : PlaceholderFactory<BrickFacade>
        {
        }
    }
}
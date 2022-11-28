using System;
using UnityEngine;
using Zenject;


namespace Arkanoid.GameElements
{
    public class BallFacade : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OnDespawned()
        {
            throw new NotImplementedException();
        }

        public void OnSpawned(IMemoryPool pool)
        {

        }

        public class Factory : PlaceholderFactory<BallFacade>
        {
        }
    }

}
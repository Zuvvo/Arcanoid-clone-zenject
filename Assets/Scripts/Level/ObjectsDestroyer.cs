using UnityEngine;
using Zenject;

namespace Arkanoid.Level
{
    public class ObjectsDestroyer : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(TagConstants.BallTag))
            {
                _signalBus.Fire<BallEscaped>();
            }
        }
    }
}
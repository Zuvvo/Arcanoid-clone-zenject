using UnityEngine;
using Arkanoid.GameElements;
using Zenject;
using Arkanoid;

public class BrickCollision : MonoBehaviour
{
    [Inject] private BrickFacade _brickFacade;
    [Inject] private readonly SignalBus _signalBus;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag(TagConstants.BallTag))
        {
            _signalBus.Fire(new BrickDestroyedSignal() { Id = _brickFacade.Id });
        }
    }
}
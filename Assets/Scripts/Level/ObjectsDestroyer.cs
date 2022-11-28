using UnityEngine;

namespace Arkanoid.Level
{
    public class ObjectsDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(TagConstants.BallTag))
            {
                Debug.Log("should destroy obj");
            }
        }
    }
}
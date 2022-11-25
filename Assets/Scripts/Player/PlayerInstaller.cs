using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;
    }

    [System.Serializable]
    public class Settings
    {
        public Rigidbody2D Rigidbody2D;
        public SpriteRenderer SpriteRenderer;
    }

}
using System;
using UnityEngine;

namespace MonsterBall.Client
{
    public class ClientMonsterController : MonoBehaviour
    {
        public static event Action<Monster> OnSpawn;
        public static event Action<Monster> OnDespawn;

        private Monster _base;

        public void Awake()
        {
            _base = gameObject.GetComponentInParent<Monster>();
            
            OnSpawn?.Invoke(_base);
        }

        public void OnDestroy()
        {
            OnDespawn?.Invoke(_base);
        }
    }
}

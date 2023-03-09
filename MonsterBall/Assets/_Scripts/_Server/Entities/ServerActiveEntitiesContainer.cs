using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MonsterBall.Server
{
    public class ServerActiveEntitiesContainer : ActiveEntitiesContainer
    {
        public static ServerActiveEntitiesContainer Instance { get; private set; }

        protected override void Awake()
        {
            Instance = this;

            base.Awake();
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}

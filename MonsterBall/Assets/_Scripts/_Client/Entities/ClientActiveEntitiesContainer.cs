using UnityEngine;

namespace MonsterBall.Client
{
    public class ClientActiveEntitiesContainer : ActiveEntitiesContainer
    {
        public static ClientActiveEntitiesContainer Instance { get; private set; }

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

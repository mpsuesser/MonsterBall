using System;
using UnityEngine;

namespace MonsterBall.Client
{
    /**
     * This class is used as a stream for in-game client-side events.
     *
     * Examples would include:
     *  - "I updated my settings to a new resolution"
     *  - "I activated my Throw toggle"
     *  - "I hover-selected this new group of entities"
     */
    public static class InGameClientSideEventStream
    {
        public static event Action<Monster> OnMonsterSpawned;
        public static event Action<Monster> OnMonsterDespawned;
        
        [RuntimeInitializeOnLoadMethod]
        public static void InitializeSubscriptions()
        {
            ClientMonsterController.OnSpawn += MonsterSpawned;
            ClientMonsterController.OnDespawn += MonsterDespawned;
        }

        private static void MonsterSpawned(Monster monster)
        {
            OnMonsterSpawned?.Invoke(monster);
        }

        private static void MonsterDespawned(Monster monster)
        {
            OnMonsterDespawned?.Invoke(monster);
        }
    }
}

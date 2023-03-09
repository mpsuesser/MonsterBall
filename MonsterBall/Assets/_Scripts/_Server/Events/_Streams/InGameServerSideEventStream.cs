using System;
using UnityEngine;

namespace MonsterBall.Server
{
    public static class InGameServerSideEventStream
    {
        public static event Action<Monster> OnMonsterSpawned;
        public static event Action<Monster> OnMonsterDespawned;
        public static event Action<PlayState> OnActivePlayStateChanged;
        
        [RuntimeInitializeOnLoadMethod]
        public static void InitializeSubscriptions()
        {
            ServerMonsterController.OnSpawn += MonsterSpawned;
            ServerMonsterController.OnDespawn += MonsterDespawned;

            PlayStateManager.OnActivePlayStateChanged += ActivePlayStateChanged;
        }

        private static void MonsterSpawned(Monster monster)
        {
            OnMonsterSpawned?.Invoke(monster);
        }

        private static void MonsterDespawned(Monster monster)
        {
            OnMonsterDespawned?.Invoke(monster);
        }

        private static void ActivePlayStateChanged(PlayState playState)
        {
            OnActivePlayStateChanged?.Invoke(playState);
        }
    }
}

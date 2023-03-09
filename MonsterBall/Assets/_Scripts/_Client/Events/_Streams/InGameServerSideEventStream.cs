using System;
using MonsterBall.Networking;
using Riptide;

namespace MonsterBall.Client
{
    /**
     * This class is used as a consumer for in-game server-side events.
     *
     * Examples would include:
     *  - "Entity X has moved to location Y"
     *  - "Entity X has despawned"
     *  - "The game state has updated to state Y"
     */
    public static class InGameServerSideEventStream
    {
        public static event Action<RiptideMessageData.StcMonsterSpawnedData>
            OnMonsterSpawnMessageReceived;
        public static event Action<RiptideMessageData.StcMonsterDespawnedData>
            OnMonsterDespawnMessageReceived;
    
        [MessageHandler((ushort) RiptideMessages.StcMonsterSpawned)]
        public static void MonsterSpawned(Message message)
        {
            RiptideMessageData.StcMonsterSpawnedData data =
                message
                    .GetSerializable<RiptideMessageData.StcMonsterSpawnedData>();
        
            OnMonsterSpawnMessageReceived?.Invoke(data);
        }

        [MessageHandler((ushort) RiptideMessages.StcMonsterDespawned)]
        public static void MonsterDespawned(Message message)
        {
            RiptideMessageData.StcMonsterDespawnedData data =
                message
                    .GetSerializable<
                        RiptideMessageData.StcMonsterDespawnedData>();

            OnMonsterDespawnMessageReceived?.Invoke(data);
        }
    }
}

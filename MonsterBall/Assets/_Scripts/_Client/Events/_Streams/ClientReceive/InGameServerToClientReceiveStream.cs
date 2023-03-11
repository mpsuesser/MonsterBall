using System;
using MonsterBall.Networking;
using Riptide;

namespace MonsterBall.Client
{
    /**
     * This class is used as a stream of in-game server-to-client messages.
     *
     * Examples would include:
     *  - "Entity X has moved to location Y"
     *  - "Entity X has despawned"
     *  - "The game state has updated to state Y"
     */
    public static class InGameServerToClientReceiveStream
    {
        [MessageHandler((ushort) RiptideMessages.StcMonsterSpawned)]
        public static void MonsterSpawned(Message message)
        {
            RiptideMessageData.StcMonsterSpawnedData data =
                message
                    .GetSerializable<RiptideMessageData.StcMonsterSpawnedData>();
        
            InGameServerSideEventConsumer.HandleMonsterSpawnMessage(data);
        }

        [MessageHandler((ushort) RiptideMessages.StcMonsterDespawned)]
        public static void MonsterDespawned(Message message)
        {
            RiptideMessageData.StcMonsterDespawnedData data =
                message
                    .GetSerializable<
                        RiptideMessageData.StcMonsterDespawnedData>();

            InGameServerSideEventConsumer.HandleMonsterDespawnMessage(data);
        }
        
        [MessageHandler((ushort) RiptideMessages.StcPlayStateUpdated)]
        public static void PlayStateUpdated(Message message)
        {
            RiptideMessageData.StcPlayStateUpdatedData data =
                message
                    .GetSerializable<
                        RiptideMessageData.StcPlayStateUpdatedData>();

            InGameServerSideEventConsumer.HandlePlayStateUpdatedMessage(data);
        }
    }
}

using MonsterBall.Networking;
using Riptide;
using UnityEngine;

namespace MonsterBall.Server
{
    public static class InGameServerToClientEventPublisher
    {
        [RuntimeInitializeOnLoadMethod]
        private static void SubscribeToPublishWorthyEvents()
        {
            InGameServerSideEventStream.OnMonsterSpawned += PublishMonsterSpawned;
            InGameServerSideEventStream.OnMonsterDespawned += PublishMonsterDespawned;
            InGameServerSideEventStream.OnActivePlayStateChanged +=
                PublishActivePlayStateChanged;
        }
        
        private static void PublishMonsterSpawned(Monster monster)
        {
            Message message = RiptideMessagePacker.PackStcMonsterSpawned(monster);
            MBServer.ActiveInstance.SendToAll(message);
        }

        private static void PublishMonsterDespawned(Monster monster)
        {
            Message message = RiptideMessagePacker.PackStcMonsterDespawned(monster);
            MBServer.ActiveInstance.SendToAll(message);
        }
        
        private static void PublishActivePlayStateChanged(PlayState playState)
        {
            Message message =
                RiptideMessagePacker.PackStcPlayStateUpdated(playState);
            MBServer.ActiveInstance.SendToAll(message);
        }
    }
}

using System;
using MonsterBall.Networking;
using Riptide;
using UnityEngine;

namespace MonsterBall.Client
{
    public static class InGameServerSideEventConsumer
    {
        [RuntimeInitializeOnLoadMethod]
        private static void SubscribeToPublishWorthyEvents()
        {
            InGameServerSideEventStream.OnMonsterSpawnMessageReceived += HandleMonsterSpawnMessage;
            InGameServerSideEventStream.OnMonsterDespawnMessageReceived +=
                HandleMonsterDespawnMessage;
        }

        private static void HandleMonsterSpawnMessage(
            RiptideMessageData.StcMonsterSpawnedData messageData
        )
        {
            ClientEntityFactory.SpawnMonster(
                messageData.EntityID,
                messageData.MonsterType,
                messageData.Position,
                messageData.Rotation
            );
        }

        private static void HandleMonsterDespawnMessage(
            RiptideMessageData.StcMonsterDespawnedData messageData
        )
        {
            if (!ClientActiveEntitiesContainer.Instance.GetMonster(
                    messageData.EntityID,
                    out Monster monster
                ))
            {
                return;
            }

            monster.Despawn();
        }
    }
}

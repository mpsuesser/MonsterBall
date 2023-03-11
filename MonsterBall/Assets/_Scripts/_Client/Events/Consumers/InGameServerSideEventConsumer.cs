using System;
using MonsterBall.Networking;
using Riptide;
using UnityEngine;

namespace MonsterBall.Client
{
    /**
     * This class is considered a Consumer because it's taking tangible action
     * based on the messages we're receiving from the server.
     */
    public static class InGameServerSideEventConsumer
    {
        public static void HandleMonsterSpawnMessage(
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

        public static void HandleMonsterDespawnMessage(
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
        
        public static void HandlePlayStateUpdatedMessage(
            RiptideMessageData.StcPlayStateUpdatedData messageData
        )
        {
            Logger.Log("CLIENT PLAYSTATE UPDATE: " + messageData.PlayState);
        }
    }
}

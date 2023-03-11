using System.Collections.Generic;
using System.Linq;
using MonsterBall.Server;
using Riptide;
using Unity.VisualScripting;
using UnityEngine;

namespace MonsterBall.Networking
{
    public static class RiptideMessagePacker
    {
        public static Message PackCtsAbilityUsageRequest(
            AbilityType abilityType,
            List<Monster> monsters
        )
        {
            List<int> monsterIDs =
                monsters.Select(monster => monster.EntID).ToList();

            RiptideMessageData.CtsAbilityUsageRequestData data =
                new()
                {
                    AbilityRequested = abilityType,
                    MonsterIDs = monsterIDs
                };

            Message message = Message.Create(
                MessageSendMode.Reliable,
                (int) RiptideMessages.CtsAbilityUsageRequest
            );
            message.AddSerializable(data);
            return message;
        }
        
        public static Message PackStcMonsterSpawned(Monster monster)
        {
            Transform transform = monster.transform;
            
            RiptideMessageData.StcMonsterSpawnedData data =
                new()
                {
                    EntityID = monster.EntID,
                    MonsterType = monster.Type,
                    Position = transform.position,
                    Rotation = transform.rotation
                };

            Message message = Message.Create(
                MessageSendMode.Reliable,
                (int) RiptideMessages.StcMonsterSpawned
            );
            message.AddSerializable(data);
            return message;
        }
        
        public static Message PackStcMonsterDespawned(Monster monster)
        {
            RiptideMessageData.StcMonsterDespawnedData data =
                new()
                {
                    EntityID = monster.EntID
                };

            Message message = Message.Create(
                MessageSendMode.Reliable,
                (int) RiptideMessages.StcMonsterDespawned
            );
            message.AddSerializable(data);
            return message;
        }
        
        public static Message PackStcPlayStateUpdated(PlayState playState)
        {
            RiptideMessageData.StcPlayStateUpdatedData data =
                new()
                {
                    PlayState = playState.StateType
                };

            Message message = Message.Create(
                MessageSendMode.Reliable,
                (int) RiptideMessages.StcPlayStateUpdated
            );
            message.AddSerializable(data);
            return message;
        }
    }
}

using System.Collections.Generic;
using Riptide;
using UnityEngine;

namespace MonsterBall.Networking
{
    public static class RiptideMessageData
    {
        public struct CtsAbilityUsageRequestData : IMessageSerializable
        {
            public AbilityType AbilityRequested;
            public List<int> MonsterIDs;
            
            public void Serialize(Message message)
            {
                message.AddInt((int) AbilityRequested);
                message.AddInt(MonsterIDs.Count);
                foreach (int monsterID in MonsterIDs)
                {
                    message.AddInt(monsterID);
                }
            }
            
            public void Deserialize(Message message)
            {
                AbilityRequested = (AbilityType) message.GetInt();
                int monsterCount = message.GetInt();
                MonsterIDs = new List<int>(monsterCount);
                for (int i = 0; i < monsterCount; i++)
                {
                    MonsterIDs.Add(message.GetInt());
                }
            }
        }
        
        public struct StcMonsterSpawnedData : IMessageSerializable
        {
            public int EntityID;
            public MonsterType MonsterType;
            public Vector3 Position;
            public Quaternion Rotation;

            public void Serialize(Message message)
            {
                message.AddInt(EntityID);
                message.AddInt((int) MonsterType);
                message.AddVector3(Position);
                message.AddQuaternion(Rotation);
            }

            public void Deserialize(Message message)
            {
                EntityID = message.GetInt();
                MonsterType = (MonsterType) message.GetInt();
                Position = message.GetVector3();
                Rotation = message.GetQuaternion();
            }
        }
        
        public struct StcMonsterDespawnedData : IMessageSerializable
        {
            public int EntityID;

            public void Serialize(Message message)
            {
                message.AddInt(EntityID);
            }

            public void Deserialize(Message message)
            {
                EntityID = message.GetInt();
            }
        }

        public struct StcPlayStateUpdatedData : IMessageSerializable
        {
            public PlayStateType PlayState;

            public void Serialize(Message message)
            {
                message.AddInt((int) PlayState);
            }

            public void Deserialize(Message message)
            {
                PlayState = (PlayStateType) message.GetInt();
            }
        }
    }
}

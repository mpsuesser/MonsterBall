using Riptide;
using UnityEngine;

namespace MonsterBall.Networking
{
    public class RiptideMessageData
    {
        public struct CtsTestSentenceData : IMessageSerializable
        {
            public string Sentence;

            public void Serialize(Message message)
            {
                message.AddString(Sentence);
            }

            public void Deserialize(Message message)
            {
                Sentence = message.GetString();
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
    }
}

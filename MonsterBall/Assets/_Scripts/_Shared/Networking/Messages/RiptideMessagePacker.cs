using Riptide;

namespace MonsterBall.Networking
{
    public class RiptideMessagePacker
    {
        public static Message PackStcMonsterSpawned(Monster monster)
        {
            RiptideMessageData.StcMonsterSpawnedData data =
                new RiptideMessageData.StcMonsterSpawnedData
                {
                    EntityID = monster.EntID,
                    MonsterType = monster.Type,
                    Position = monster.transform.position,
                    Rotation = monster.transform.rotation
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
                new RiptideMessageData.StcMonsterDespawnedData
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
        
        // TODO: Test that we can use this function ^ and send from C to S
        
        public static RiptideMessageData.CtsTestSentenceData UnpackCtsTestSentence(Message message)
        {
            RiptideMessageData.CtsTestSentenceData data =
                message.GetSerializable<RiptideMessageData.CtsTestSentenceData>();
            
            return data;
        }
    }
}

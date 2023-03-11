using MonsterBall.Client;
using MonsterBall.Networking;
using Riptide;

namespace MonsterBall.Server
{
    public class InGameClientToServerReceiveStream
    {
        [MessageHandler((ushort) RiptideMessages.CtsAbilityUsageRequest)]
        public static void AbilityUsageRequest(Message message)
        {
            RiptideMessageData.CtsAbilityUsageRequestData data =
                message
                    .GetSerializable<RiptideMessageData.CtsAbilityUsageRequestData>();
        
            // TODO: CONTINUE, stopped to split event types
        }
    }
}

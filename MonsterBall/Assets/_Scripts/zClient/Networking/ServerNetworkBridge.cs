namespace MonsterBall.Client.Networking
{
    public class ServerNetworkBridge : NetworkBridge
    {
        public ServerNetworkBridge() : base()
        {
            
        }
        
        public override void SendMessageToServer(string message)
        {
            Logger.Log($"TO SERVER: {message}");
        }
    }
}

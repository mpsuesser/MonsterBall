namespace MonsterBall.Client.Game
{
    public class GameManager
    {
        public static GameManager Active = null;
        
        private readonly Networking.NetworkBridge _bridge;
        private readonly GameState _state;
        
        public GameManager(Networking.NetworkBridge bridge)
        {
            _bridge = bridge;
            _state = new GameState();

            Active = this;
        }

        public void SendTestMessage()
        {
            _bridge.SendMessageToServer("This is a test!");
        }
    }
}

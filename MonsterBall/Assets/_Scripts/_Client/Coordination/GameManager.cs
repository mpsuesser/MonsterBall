namespace MonsterBall.Client.Game
{
    public class GameManager
    {
        public static GameManager ActiveInstance { get; private set; }
        
        private readonly GameState _state;
        
        public GameManager()
        {
            _state = new GameState();

            ActiveInstance = this;
        }

        public void SendTestMessage()
        {
            // _bridge.SendMessageToServer("This is a test!");
        }
    }
}

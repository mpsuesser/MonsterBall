using UnityEngine.SceneManagement;

namespace MonsterBall.Client
{
    public static class GamePortal
    {
        public static void LaunchLocallyBridgedGame()
        {
            Networking.NetworkBridge bridge = new Networking.LocalNetworkBridge();
            LaunchGameWithBridge(bridge);
        }

        private static void LaunchGameWithBridge(Networking.NetworkBridge bridge)
        {
            Game.GameManager manager = new Game.GameManager(bridge);

            SceneManager.LoadSceneAsync(
                (int)SceneIndex.Field,
                LoadSceneMode.Additive
            );
        }
    }
}

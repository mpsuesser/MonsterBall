using MonsterBall.Client.Networking;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

namespace MonsterBall.Client
{
    public static class GamePortal
    {
        public static async UniTask LaunchLocallyBridgedGame()
        {
            await SceneManager.LoadSceneAsync(
                (int) SceneIndex.ServerStartupPreload,
                LoadSceneMode.Additive
            );
            await SceneManager.LoadSceneAsync(
                (int)SceneIndex.ServerNetworking,
                LoadSceneMode.Additive
            );
            
            await SceneManager.LoadSceneAsync(
                (int) SceneIndex.ClientStartupPreload,
                LoadSceneMode.Additive
            );
            await SceneManager.LoadSceneAsync(
                (int)SceneIndex.ClientNetworking,
                LoadSceneMode.Additive
            );
            MBClient.ActiveInstance.InitializeLocalConnection();

            await SceneManager.LoadSceneAsync(
                (int)SceneIndex.Field,
                LoadSceneMode.Additive
            );
            await SceneManager.LoadSceneAsync(
                (int)SceneIndex.ClientInGame,
                LoadSceneMode.Additive
            );
            await SceneManager.LoadSceneAsync(
                (int)SceneIndex.ServerInGame,
                LoadSceneMode.Additive
            );
            await SceneManager.LoadSceneAsync(
                (int)SceneIndex.ClientUI,
                LoadSceneMode.Additive
            );
        }
    }
}

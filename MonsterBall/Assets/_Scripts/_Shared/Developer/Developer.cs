using System.Collections.Generic;
using MonsterBall.Client;
using UnityEditor;
using Cysharp.Threading.Tasks;
using MonsterBall.Server;
using UnityEngine.SceneManagement;

namespace MonsterBall
{
    public static class Developer
    {
        [MenuItem("Developer/Launch Client")]
        public static async UniTask LaunchClient()
        {
            await SceneManager.LoadSceneAsync(
                (int) SceneIndex.ClientStartupPreload,
                LoadSceneMode.Additive
            );
        }

        [MenuItem("Developer/Launch Server")]
        public static async UniTask LaunchServer()
        {
            await SceneManager.LoadSceneAsync(
                (int) SceneIndex.ServerStartupPreload,
                LoadSceneMode.Additive
            );
        }

        [MenuItem("Developer/Load Locally-Bridged Game")]
        public static async UniTask LoadLocallyBridgedGame()
        {
            await GamePortal.LaunchLocallyBridgedGame();
        }

        [MenuItem("Developer/(Server) Initiate Sequence: First Throw")]
        public static void InitiateSequenceFirstThrow()
        {
            Sequence seq = new Server.Sequences.FirstThrow();
            SequenceRunner.AddToQueue(seq);
            SequenceRunner.RunThroughQueue();
        }

        [MenuItem("Developer/(Server) Despawn All Monsters")]
        public static void DespawnAllMonsters()
        {
            IEnumerable<Monster> monsters =
                ServerActiveEntitiesContainer.Instance.GetAllMonsters();
            foreach (Monster monster in monsters)
            {
                monster.Despawn();
            }
        }
    }
}

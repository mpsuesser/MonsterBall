using MonsterBall.Client;
using MonsterBall.Client.Game;
using UnityEditor;

namespace MonsterBall
{
    public static class Developer
    {
        [MenuItem("Developer/Client/Validate Active Game Manager")]
        public static void ValidateActiveGameManager()
        {
            if (GameManager.Active == null)
            {
                Logger.Log("No GameManager is active!");
                return;
            }
            
            GameManager.Active.SendTestMessage();
        }

        [MenuItem("Developer/Client/Load Locally-Bridged Game")]
        public static void LoadLocallyBridgedGame()
        {
            GamePortal.LaunchLocallyBridgedGame();
        }

        [MenuItem("Developer/Client/Initiate Sequence: First Throw")]
        public static void InitiateSequenceFirstThrow()
        {
            Sequence seq = new Client.Sequences.FirstThrow();
            SequenceRunner.AddToQueue(seq);
            SequenceRunner.RunThroughQueue();
        }
    }
}

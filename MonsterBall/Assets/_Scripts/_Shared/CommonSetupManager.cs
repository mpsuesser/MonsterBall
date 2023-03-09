using Riptide.Utils;
using UnityEngine;

namespace MonsterBall
{
    public class CommonSetupManager : MonoBehaviour
    {
        private void Awake()
        {
            RiptideLogger.Initialize(
                Debug.Log,
                Debug.Log,
                Debug.LogWarning,
                Debug.LogError,
                false
            );
        }
    }
}

using UnityEngine;

namespace MonsterBall
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Debug.Log(message);
        }

        public static void LogError(string message)
        {
            Debug.LogError(message);
        }
    }
}

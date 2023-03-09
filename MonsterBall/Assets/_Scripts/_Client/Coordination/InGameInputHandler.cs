using UnityEngine;

namespace MonsterBall.Client
{
    public class InGameInputHandler : MonoBehaviour
    {
        private void Update()
        {
            // temp
            if (Input.GetKeyDown(KeyCode.T))
            {
                try
                {
                    Vector3 point = CameraUtilities.GetFieldPointOfClick();
                    Logger.Log($"Field click found: {point}");
                }
                catch (FieldClickNotFoundException)
                {
                    Logger.Log("Field click not found!");
                }
            }
        }
    }
}

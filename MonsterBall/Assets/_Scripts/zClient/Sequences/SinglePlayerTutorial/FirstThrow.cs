using UnityEngine;

namespace MonsterBall.Client.Sequences
{
    public class FirstThrow : Sequence
    {
        protected override void SetupSequence()
        {
            Logger.Log("[First Throw] Setup");
            // Spawn QB Monster
            // Give ball
            
            // Eventually...
            // - Show some walkthrough text
        }

        protected override void Begin()
        {
            Logger.Log("[First Throw] Begin");
            // Unlock movement
        }

        protected override void HookIntoCompletionTrigger()
        {
            Logger.Log("[First Throw] Hook into completion trigger");
            // Hook into "ball hit the ground" event
        }

        protected override void UnhookCompletionTrigger()
        {
            Logger.Log("[First Throw] Unhook from completion trigger");
            // Unhook from event
        }
    }
}

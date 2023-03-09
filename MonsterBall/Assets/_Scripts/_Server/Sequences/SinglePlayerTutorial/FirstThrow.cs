using UnityEngine;

namespace MonsterBall.Server.Sequences
{
    public class FirstThrow : Sequence
    {
        protected override void SetupSequence()
        {
            Logger.Log("[First Throw] Setup");
            Quarterback qb = ServerEntityFactory.SpawnMonster(
                MonsterType.Quarterback,
                Vector3.zero,
                Quaternion.identity
            ) as Quarterback;
            
            // Give ball

            // Eventually...
            // - Show some walkthrough text
            //   - This can be done by sending async-awaited message signals
            //     to the client; the client can handle the display and effects
            //     while the server side either waits or handles the sequencing
            //     itself.
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

        protected override void UnhookFromCompletionTrigger()
        {
            Logger.Log("[First Throw] Unhook from completion trigger");
            // Unhook from event
        }
    }
}

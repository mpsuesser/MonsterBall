using System;

namespace MonsterBall.Server
{
    public class PrePlayState : PlayState
    {
        public static event Action<PrePlayState, PrePlayOutcome>
            OnPrePlayStateEnded;
        
        public override PlayStateType StateType => PlayStateType.PreSnap;

        public PrePlayState(
            TeamType offensiveTeam,
            int down,
            int lineOfScrimmageYardMarker,
            int firstDownYardMarker
        )
        {
            OffensiveTeam = offensiveTeam;
            Down = down;
            LineOfScrimmageYardMarker = lineOfScrimmageYardMarker;
            FirstDownYardMarker = firstDownYardMarker;
        }

        public override void Begin()
        {
            // Initiate play clock, subscribe to run-out event
            // Subscribe to QB Hike event
        }
    }
}

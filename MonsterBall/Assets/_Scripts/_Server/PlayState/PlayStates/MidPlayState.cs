using System;

namespace MonsterBall.Server
{
    public class MidPlayState : PlayState
    {
        public static event Action<MidPlayState, MidPlayOutcome>
            OnMidPlayStateEnded;
        
        public override PlayStateType StateType => PlayStateType.MidPlay;
        
        public MidPlayState(PrePlayState prePlayState)
        {
            OffensiveTeam = prePlayState.OffensiveTeam;
            Down = prePlayState.Down;
            LineOfScrimmageYardMarker = prePlayState.LineOfScrimmageYardMarker;
            FirstDownYardMarker = prePlayState.FirstDownYardMarker;
        }

        public override void Begin()
        {
            
        }

        public override void CleanUp()
        {
            
        }
    }
}

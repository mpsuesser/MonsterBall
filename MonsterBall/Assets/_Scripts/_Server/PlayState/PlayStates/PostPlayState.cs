using System;

namespace MonsterBall.Server
{
    public class PostPlayState : PlayState
    {
        public static event Action<PostPlayState, PostPlayOutcome> OnPostPlayStateEnded;
        
        public override PlayStateType StateType => PlayStateType.PostPlay;
        
        public PostPlayState(
            MidPlayState midPlayState
            /*, PlayOutcome playOutcome*/
        )
        {
            OffensiveTeam = midPlayState.OffensiveTeam;
            Down = midPlayState.Down;
            LineOfScrimmageYardMarker = midPlayState.LineOfScrimmageYardMarker;
            FirstDownYardMarker = midPlayState.FirstDownYardMarker;
        }

        public override void Begin()
        {
            
        }
    }
}

using System;

namespace MonsterBall.Server
{
    public class PrePlayState : PlayState
    {
        public static event Action<PrePlayState, PrePlayOutcome>
            OnPrePlayStateEnded;
        
        public override PlayStateType StateType => PlayStateType.PreSnap;

        private ServerPlayClock _playClock;

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
            _playClock =
                ServerPlayClock.Create(Constants.Game.PlayClockSeconds);
            _playClock.OnPlayClockExpiration += PlayClockExpired;
            
            // Subscribe to QB Hike event
        }

        public override void CleanUp()
        {
            if (_playClock)
            {
                _playClock.Kill();
            }
        }

        private void PlayClockExpired()
        {
            PrePlayOutcome outcome =
                new PrePlayOutcome(PrePlayOutcomeType.PlayClockExpired);
            OnPrePlayStateEnded?.Invoke(this, outcome);
        }
    }
}

using System;
using UnityEngine;

namespace MonsterBall.Server
{
    public class PlayStateManager : MonoBehaviour
    {
        public static event Action<PlayState> OnActivePlayStateChanged;
        
        public static PlayStateManager Instance { get; private set; }
        
        private PlayState _activePlayState;
        
        private void Awake()
        {
            Instance = this;
            _activePlayState = null;
            
            SubscribeToPlayStateEvents();
        }
        private void OnDestroy() => Instance = null;

        private void SubscribeToPlayStateEvents()
        {
            PrePlayState.OnPrePlayStateEnded += PrePlayStateEnded;
            MidPlayState.OnMidPlayStateEnded += MidPlayStateEnded;
            PostPlayState.OnPostPlayStateEnded += PostPlayStateEnded;
        }

        private void PrePlayStateEnded(PrePlayState prePlayState, PrePlayOutcome outcome)
        {
            switch (outcome.OutcomeType)
            {
                case PrePlayOutcomeType.PlayClockExpired:
                    PlayState adjustedPreState = new PrePlayState(
                        prePlayState.OffensiveTeam,
                        prePlayState.Down,
                        Utils.GetNewYardageAfterLoss(
                            prePlayState.LineOfScrimmageYardMarker,
                            5,
                            prePlayState.OffensiveTeam
                        ),
                        prePlayState.FirstDownYardMarker
                    );
                    ActivatePlayState(adjustedPreState);
                    break;
                
                case PrePlayOutcomeType.Hike:
                    // TODO: Send ball to QB
                    PlayState midState = new MidPlayState(prePlayState);
                    break;
            }
        }

        private void MidPlayStateEnded(MidPlayState midPlayState, MidPlayOutcome outcome)
        {
            switch (outcome.OutcomeType)
            {
                case MidPlayOutcomeType.Touchdown:
                    // TODO
                    break;
                
                case MidPlayOutcomeType.IncompletePass:
                    // TODO
                    break;
                
                case MidPlayOutcomeType.BallCarrierTackled:
                    // TODO
                    break;
                
                case MidPlayOutcomeType.BallCarrierRanOutOfBounds:
                    // TODO
                    break;
            }
        }

        private void PostPlayStateEnded(PostPlayState postPlayState, PostPlayOutcome outcome)
        {
            switch (outcome.OutcomeType)
            {
                case PostPlayOutcomeType.FirstDown:
                    // TODO
                    break;
                
                case PostPlayOutcomeType.NextDown:
                    // TODO
                    break;
                
                case PostPlayOutcomeType.TurnoverFollowingInterception:
                    // TODO
                    break;
                
                case PostPlayOutcomeType.TurnoverFollowingTouchdown:
                    // TODO
                    break;
                
                case PostPlayOutcomeType.TurnoverOnDowns:
                    // TODO
                    break;
            }
        }
        
        public void StartFresh()
        {
            PlayState freshState = new PrePlayState(
                TeamType.Goodies, 
                1, 
                50, 
                60
            );
            ActivatePlayState(freshState);

            // From here onward, until the end of the game, we let event-based
            // transitions guide us through the play states.

            // This would be called from the FirstThrow sequence Init() method.
        }

        public void ActivatePlayState(PlayState newPlayState)
        {
            _activePlayState?.CleanUp();
            
            _activePlayState = newPlayState;
            _activePlayState.Begin();
            
            OnActivePlayStateChanged?.Invoke(_activePlayState);
        }
    }
}

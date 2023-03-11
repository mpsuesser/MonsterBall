namespace MonsterBall.Server
{
    /**
     * PlayStates are intended to be used for setting up the hooks and then
     * signalling the events that lead to the conclusion of the state.
     *
     * They are for visibility and decoupled control. They should _not_ be
     * micromanaging every detail of the game state.
     */
    public abstract class PlayState
    {
        public abstract PlayStateType StateType { get; }
        
        /**
         * The data below gets passed onward as we transition from
         * PrePlay -> MidPlay -> PostPlay. Transitioning from PostPlay
         * to PrePlay, we update the data based on the outcome of the play.
         */
        public TeamType OffensiveTeam { get; protected set; }
        public TeamType DefensiveTeam =>
            OffensiveTeam == TeamType.Goodies
                ? TeamType.Baddies
                : TeamType.Goodies;
        
        public int LineOfScrimmageYardMarker { get; protected set; }
        public int FirstDownYardMarker { get; protected set; }
        public int Down { get; protected set; }

        public abstract void Begin();
        public abstract void CleanUp();
    }
}

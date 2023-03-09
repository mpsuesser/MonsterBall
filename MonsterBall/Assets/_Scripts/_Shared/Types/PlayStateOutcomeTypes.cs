namespace MonsterBall
{
    public enum PrePlayOutcomeType
    {
        Hike = 1,
        PlayClockExpired,
    }

    public enum MidPlayOutcomeType
    {
        BallCarrierTackled = 1,
        BallCarrierRanOutOfBounds,
        IncompletePass,
        Touchdown,
    }

    public enum PostPlayOutcomeType
    {
        NextDown = 1,
        FirstDown,
        TurnoverOnDowns,
        TurnoverFollowingInterception,
        TurnoverFollowingTouchdown,
    }
}

namespace MonsterBall.Server
{
    public class MidPlayOutcome
    {
        public MidPlayOutcomeType OutcomeType { get; }
        
        public MidPlayOutcome(MidPlayOutcomeType outcomeType)
        {
            OutcomeType = outcomeType;
        }
    }
}

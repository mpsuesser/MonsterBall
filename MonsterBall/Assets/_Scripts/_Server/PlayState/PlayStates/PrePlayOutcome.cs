namespace MonsterBall.Server
{
    public class PrePlayOutcome
    {
        public PrePlayOutcomeType OutcomeType { get; }
        
        public PrePlayOutcome(PrePlayOutcomeType outcomeType)
        {
            OutcomeType = outcomeType;
        }
    }
}

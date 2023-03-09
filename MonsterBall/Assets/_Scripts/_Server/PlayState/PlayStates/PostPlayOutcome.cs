namespace MonsterBall.Server
{
    public class PostPlayOutcome
    {
        public PostPlayOutcomeType OutcomeType { get; }
        
        public PostPlayOutcome(PostPlayOutcomeType outcomeType)
        {
            OutcomeType = outcomeType;
        }
    }
}

namespace MonsterBall
{
    public class Utils
    {
        public static int GetNewYardageAfterLoss(
            int currentYardage,
            int loss,
            TeamType teamType
        )
        {
            return teamType == TeamType.Goodies
                ? currentYardage - loss
                : currentYardage + loss;
        }
    }
}

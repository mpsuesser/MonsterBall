namespace MonsterBall
{
    public class Runningback : Monster
    {
        public override MonsterType Type => MonsterType.Runningback;
        
        public override bool CanOwnBall => true;
    }
}

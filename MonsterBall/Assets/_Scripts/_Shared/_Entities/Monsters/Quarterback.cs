namespace MonsterBall
{
    public class Quarterback : Monster
    {
        public override MonsterType Type => MonsterType.Quarterback;
        
        public override bool CanOwnBall => true;
    }
}

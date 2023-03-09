namespace MonsterBall
{
    public class TightEnd : Monster
    {
        public override MonsterType Type => MonsterType.TightEnd;
        
        public override bool CanOwnBall => false;
    }
}

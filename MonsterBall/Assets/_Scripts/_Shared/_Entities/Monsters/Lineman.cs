namespace MonsterBall
{
    public class Lineman : Monster
    {
        public override MonsterType Type => MonsterType.Lineman;
        
        public override bool CanOwnBall => false;
    }
}

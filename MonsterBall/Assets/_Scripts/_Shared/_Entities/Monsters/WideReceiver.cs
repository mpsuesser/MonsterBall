namespace MonsterBall
{
    public class WideReceiver : Monster
    {
        public override MonsterType Type => MonsterType.WideReceiver;
        
        public override bool CanOwnBall => true;
    }
}

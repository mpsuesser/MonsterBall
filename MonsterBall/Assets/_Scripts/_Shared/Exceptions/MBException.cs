using System;

namespace MonsterBall
{
    public abstract class MBException : Exception
    {
        protected MBException(string message = null) : base(message)
        {
            
        }
    }
}

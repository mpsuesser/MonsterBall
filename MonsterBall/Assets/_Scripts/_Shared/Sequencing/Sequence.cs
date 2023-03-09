using System;

namespace MonsterBall
{
    /**
     * Like an animation, but for code.
     */
    public abstract class Sequence
    {
        public event Action<Sequence> OnCompleted;

        protected abstract void SetupSequence();
        protected abstract void Begin();
        protected abstract void HookIntoCompletionTrigger();
        protected abstract void UnhookFromCompletionTrigger();

        public void Run()
        {
            SetupSequence();
            HookIntoCompletionTrigger();
            Begin();
        }
        
        protected virtual void Completed()
        {
            UnhookFromCompletionTrigger();
            OnCompleted?.Invoke(this);
        }
    }
}

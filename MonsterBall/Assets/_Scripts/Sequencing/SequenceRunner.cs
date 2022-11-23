using System.Collections.Generic;

namespace MonsterBall
{
    public static class SequenceRunner
    {
        private static readonly Queue<Sequence> PendingSequences
            = new Queue<Sequence>();

        public static void AddToQueue(Sequence sequence)
        {
            PendingSequences.Enqueue(sequence);
        }

        public static void RunThroughQueue()
        {
            RunNextSequenceInQueue();
        }
        
        private static void RunSequence(Sequence sequence)
        {
            sequence.OnCompleted += ActiveSequenceCompleted;
            sequence.Run();
        }

        private static void ActiveSequenceCompleted(Sequence sequence)
        {
            sequence.OnCompleted -= ActiveSequenceCompleted;
            
            RunNextSequenceInQueue();
        }

        private static void RunNextSequenceInQueue()
        {
            if (PendingSequences.TryDequeue(out Sequence nextSequence))
            {
                RunSequence(nextSequence);
            }
        }
    }
}
